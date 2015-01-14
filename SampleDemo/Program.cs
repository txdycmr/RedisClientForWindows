using System;
using ServiceStack.Redis;

namespace SampleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            const string host = "127.0.0.1";
            const string testKeyName = "name";

            using (var redisClient = new RedisClient(host))
            {
                if (!redisClient.ContainsKey(testKeyName))
                {
                    //Adds key and Sets value.
                    redisClient.Set(testKeyName, "txdycmr");
                }

                Console.WriteLine("My name is: " + redisClient.Get<string>(testKeyName));
                Console.WriteLine("Next I change my name into Yanshun Guo..");

                //Changes the value of key named "name".
                redisClient.Set(testKeyName, "Yanshun_Guo");
                Console.WriteLine("Now my name is: " + redisClient.Get<string>(testKeyName));
            }

            Console.Read();
        }
    }
}
