using System;
using BooksApi.Models;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json;
using org.openstars.core.bigset.Generic;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;
using Thrift.Transport.Client;

namespace BooksApi.Services.transport
{
    public class BigSetGenericKVClient
    {
        public static void Main()
        {
            try
            {
                TTransport transport = new TSocketTransport("127.0.0.1", 18990, 1000000);
                TProtocol protocol = new TBinaryProtocol(transport);
                TStringBigSetKVService.Client client = new TStringBigSetKVService.Client(protocol);
        
                if (transport.IsOpen)
                {
                    Book book = new Book();
                    book.Author = "Auth";
                    book.Category = "Category";
                    book.Id = "12123";
                    book.Price = 10123;
                    book.BookName = "Book Name";

                    var bookJson = JsonConvert.SerializeObject(book);
                    Console.WriteLine(bookJson, "bookJson");
        
                    // client.bsPutItemAsync("Test", new TItem(new []{}))
                    // Console.WriteLine("ping()");
                    //
                    // int sum = client.add(1, 1);
                    // Console.WriteLine("1+1={0}", sum);
                    //
                    // Work work = new Work();
                    //
                    // work.Op = Operation.DIVIDE;
                    // work.Num1 = 1;
                    // work.Num2 = 0;
                    // try
                    // {
                    //     int quotient = client.calculate(1, work);
                    //     Console.WriteLine("Whoa we can divide by 0");
                    // }
                    // catch (InvalidOperation io)
                    // {
                    //     Console.WriteLine("Invalid operation: " + io.Why);
                    // }
                    //
                    // work.Op = Operation.SUBTRACT;
                    // work.Num1 = 15;
                    // work.Num2 = 10;
                    // try
                    // {
                    //     int diff = client.calculate(1, work);
                    //     Console.WriteLine("15-10={0}", diff);
                    // }
                    // catch (InvalidOperation io)
                    // {
                    //     Console.WriteLine("Invalid operation: " + io.Why);
                    // }
                    //
                    // SharedStruct log = client.getStruct(1);
                    // Console.WriteLine("Check log: {0}", log.Value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}