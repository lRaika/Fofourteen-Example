﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Прочитать содержимое XML файла со списком последних новостей по ссылке https://habrahabr.ru/rss/interesting/
            //Создать класс Item со свойствами: Title, Link, Description, PubDate.
            //Создать коллекцию типа List< Item > и записать в нее данные из файла.
            
            XmlDocument document = new XmlDocument();
            List<Item> items = new List<Item>();
            document.Load("https://habrahabr.ru/rss/interesting/");
            XmlNode node = document.DocumentElement;
            XmlNode channel = node["channel"];
            int itemCount = 1;
            if (channel.HasChildNodes)
            {
                foreach (XmlNode otherNode in channel.ChildNodes)
                {
                    if(otherNode.Name == "item")
                    {
                        Item item = new Item();
                        item.Title = otherNode["title"].InnerText;
                        item.Link = otherNode["link"].InnerText;
                        item.Description = otherNode["description"].InnerText;
                        item.PubDate = otherNode["pubDate"].InnerText;
                        items.Add(item);
                    }
                }
            }
            foreach (var item in items)
            {
                Console.WriteLine("item :  №{0} ",itemCount);
                Console.WriteLine("Title : {0}",item.Title);
                Console.WriteLine("Link : {0}",item.Link);
                Console.WriteLine("Description : {0}", item.Description);
                Console.WriteLine("PubDate : {0}", item.PubDate);
                itemCount++;
            }
            Console.ReadLine();

        }
    }
}
