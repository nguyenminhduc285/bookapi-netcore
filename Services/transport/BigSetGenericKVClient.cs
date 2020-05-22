using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using org.openstars.core.bigset.Generic;
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
                IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
                TTransport transport = new TSocketTransport(ipaddress, 18990, 100000);
                TFramedTransport tFrameTransport = new TFramedTransport(transport);
                TProtocol protocol = new TBinaryProtocol(tFrameTransport);
                TStringBigSetKVService.Client client = new TStringBigSetKVService.Client(protocol);

                client.OpenTransportAsync();
                Console.WriteLine("transport.IsOpen");
                Console.WriteLine(transport.IsOpen);
                
                if (transport.IsOpen)
                {
                    // Book book = new Book();
                    // book.Author = "Auth";
                    // book.Category = "Category";
                    // book.Id = "12123";
                    // book.Price = 10123;
                    // book.BookName = "Book Name";
                    //
                    // var bookJson = JsonConvert.SerializeObject(book);
                    // var bJson = Encoding.ASCII.GetBytes(bookJson);;
                    // var str = Encoding.UTF8.GetString(bJson);
                    // // Console.WriteLine(bJson);
                    // Console.WriteLine(str);
                    // var tItem = new TItem();
                    // tItem.Key = Encoding.ASCII.GetBytes(book.Id);
                    // tItem.Value = bJson;
                    //
                    // var bsPutItemAsync = client.bsPutItemAsync("Test", tItem);
                    // Console.WriteLine(bsPutItemAsync.IsCompleted);
                    // if (bsPutItemAsync.IsCompleted == false)
                    // {
                    //     bsPutItemAsync.Wait();
                    // }
                    // // ========================

                    // var serializeObject = JsonConvert.SerializeObject(bsPutItemAsync);
                    // Console.WriteLine(serializeObject);
                    
                    // Get data from thrift
                    var bsGetItemAsync = client.bsGetItemAsync("Test", Encoding.ASCII.GetBytes("12123"));
                    // bsGetItemAsync.Start();
                    // bsGetItemAsync.RunSynchronously();
                    
                    Console.WriteLine("serializeObject: ");
                    Console.WriteLine(bsGetItemAsync.IsCanceled);
                    Console.WriteLine(bsGetItemAsync.IsFaulted);
                    Console.WriteLine(bsGetItemAsync.IsCompleted);
                    if (bsGetItemAsync.IsCompleted == false)
                    {
                        Console.WriteLine("bsGetItemAsync.IsCompleted == false");
                        bsGetItemAsync.Wait();
                    }
                    Console.WriteLine(bsGetItemAsync.IsCompletedSuccessfully);
                    Console.WriteLine(bsGetItemAsync.Status);
                    Console.WriteLine(bsGetItemAsync.Id);
                    // bsGetItemAsync.Wait();
                    
                    Console.WriteLine(bsGetItemAsync.ToString());
                    // Console.WriteLine(bsGetItemAsync.Result.Item.Value);
                    var obj = Encoding.UTF8.GetString(bsGetItemAsync.Result.Item.Value);
                    Console.WriteLine(obj);
                    // ==========================
                    
                    
                    
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
                Console.WriteLine(e.Data);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}