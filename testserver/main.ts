import { Application } from "https://deno.land/x/oak/mod.ts";

const app = new Application();

app.use((ctx) => {
  ctx.response.body = "Hello world!";
});

await app.listen({ port: 8000 });


/*
inbox:
    response


read:
    response
    request

send:
    request
*/



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
inbox("Mikkel", data);
read("Mikkel", data, 1);
const mail1: Mail = {title: "ajifjeif", content:"content", id: 3, sender: "Theis"};
send("Theis", "Simon", data, mail1);
console.log(data["Simon"])

function read(user: string, mailData: MailData, req: number): Mail {
    return mailData[user][req-1];
}

function send(fromUser: string, toUser: string, mailData: MailData, mail: Mail) {
    mail.sender = fromUser;
    mail.id = generateId(toUser, mailData);
    mailData[toUser].push(mail);
}