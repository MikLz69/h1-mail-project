### To run program type:
```
dotnet run
```
### To run server
```
deno run --allow-net --watch main.ts
```
### Commands for testing server
```
curl -X GET localhost/read
```
```
curl -X POST localhost/read?keyvalue=value && keyvalue2=value2
```
```
curl -X GET localhost/inbox
```
```
curl -X POST localhost/send
```