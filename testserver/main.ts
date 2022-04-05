// import { Application } from "https://deno.land/x/oak/mod.ts";

// const app = new Application();

// app.use((ctx) => {
//   ctx.response.body = "Hello world!";
// });

// await app.listen({ port: 8000 });


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
            id: 0,
            sender: "Theis",
        },
        {
            title: "bruh moment 2",
            content: "top 5 bruh momentos 2",
            id: 1,
            sender: "Dietz",
        },
    ],
    "Simon": [],
    "Theis": [],
    "Maksim": [],
};

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

// function read(user: string, mailData: MailData, request: ): Mail {
//     for (const v in mailData[user]) {
        
//     }


// }
