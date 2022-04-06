import { Application } from "https://deno.land/x/oak@v10.5.1/mod.ts";

type Mail = {
    title: string,
    content: string,
    id: number,
    sender: string,
};

type InboxEntry = {
    title: string,
    sender: string,
};

type MailData = {[key: string]: Mail[]};

const data: MailData = {
    "Mikkel": [
        {
            title: "bruh moment",
            content: "top 5 bruh momentos",
            id: 1,
            sender: "Theis",
        },
        {
            title: "bruh moment 2",
            content: "top 5 bruh momentos 2",
            id: 2,
            sender: "Dietz",
        },
    ],
    "Simon": [],
    "Theis": [],
    "Maksim": [],
};

function generateId(user: string, mailData: MailData): number{
    
    let id = mailData[user].length;
    let i = 0;
    for (const v in mailData[user]) {
        id = mailData[user][i].id;
        i++;
    }
    id += 1;
    return id;
}

function inbox(user: string, mailData: MailData): InboxEntry[] {
    const inboxEntries: InboxEntry[] = [];
    let i = 0;
    for (const v in mailData[user]) {
        const inboxEntry: InboxEntry = {title: "", sender: ""};
        inboxEntry.title = mailData[user][i].title;
        inboxEntry.sender = mailData[user][i].sender;
        inboxEntries[i] = inboxEntry;
        i++;
    }
    return inboxEntries;
}

function read(user: string, mailData: MailData, req: number): Mail {
    return mailData[user][req-1];
}

function send(fromUser: string, toUser: string, mailData: MailData, mail: Mail): {msg: "Ok" | "Could not send"} {
    if (typeof mail == "undefined") {
        throw new Error("mail is undefined")
    }
    mail.sender = fromUser;
    mail.id = generateId(toUser, mailData);
    mailData[toUser].push(mail);
    return {msg: "Ok"}
}

function test_logic() {
    console.log(send("Theis", "Mikkel", data, {title: "aisfji", content: "asdasfa", id: 0, sender: "Theis"}));
}
test_logic();

const app = new Application(); 

app.use (async(ctx) => {
    const path = ctx.request.url.pathname;
    const method = ctx.request.method;
    if (path === '/inbox' && method === 'GET') {
        const params = ctx.request.url.searchParams
        ctx.response.body = inbox(params.get("user")!, data)
    }
    else if (path === '/read' && method === 'GET') {
        const params = ctx.request.url.searchParams
        ctx.response.body = read(params.get("user")!, data, parseInt(params.get("number")!));
    }
    else if (path === '/send' && method === 'POST') {
        const body: SendRequestBody = await ctx.request.body({type: 'json'}).value
        type SendRequestBody = {
            fromUser: string,
            toUser: string,
            mail: Mail,
        }
        ctx.response.body = send(body.fromUser, body.toUser, data, body.mail)
    } else {
        ctx.response.body = `path=${path} method=${method}`;
    }
});

/*
curl localhost:8000/send -X POST -H "Content-Type: application/json" -d '{"username":"xyz","password":"xyz"}'
*/
console.log("xXserver startedXx")
await app.listen({ port: 8000 });
