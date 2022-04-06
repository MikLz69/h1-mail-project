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
curl -X POST localhost/read?keyvalue=value&keyvalue2=value2
```
```
curl -X GET localhost/inbox
```
```
curl -X POST localhost/send
```

## Resources

- [HttpClient - Zetcode.com](https://zetcode.com/csharp/httpclient/)
- [Asynchronous programming - MS Docs](https://docs.microsoft.com/en-us/dotnet/csharp/async)
- [How to serialize and deserialize JSON - MS Docs](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-6-0)
