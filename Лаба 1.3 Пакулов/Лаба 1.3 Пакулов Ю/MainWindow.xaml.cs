using System;
using System.Collections.Generic;
using System.Xml;

/// <summary>
/// Класс для представления события в логе
/// </summary>
class Event
{
    public string Date { get; set; } // Дата и время события
    public string Result { get; set; } // Результат события (например, успех или ошибка)
    public string IpFrom { get; set; } // IP-адрес отправителя
    public string Method { get; set; } // HTTP-метод (GET, POST и т.д.)
    public string UrlTo { get; set; } // URL, куда был отправлен запрос
    public string Response { get; set; } // HTTP-код ответа
}

/// <summary>
/// Класс для представления лога событий
/// </summary>
class Log
{
    public List<Event> Events { get; set; } // Список событий в логе

    public Log()
    {
        Events = new List<Event>();
    }
}

/// <summary>
/// Класс для парсинга XML и создания объектов лога
/// </summary>
class XmlParser
{
    public static Log ParseXml(string xmlString)
    {
        // Создание объекта для хранения событий лога
        Log log = new Log();

        // Загрузка XML
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlString);

        // Получение всех элементов <event>
        XmlNodeList eventNodes = doc.DocumentElement.SelectNodes("event");

        // Обход всех <event> элементов
        foreach (XmlNode eventNode in eventNodes)
        {
            // Создание объекта Event на основе данных из XML
            Event e = new Event();
            e.Date = eventNode.Attributes["date"].Value;
            e.Result = eventNode.Attributes["result"].Value;
            e.IpFrom = eventNode.SelectSingleNode("ip-from").InnerText;
            e.Method = eventNode.SelectSingleNode("method").InnerText;
            e.UrlTo = eventNode.SelectSingleNode("url-to").InnerText;
            e.Response = eventNode.SelectSingleNode("response").InnerText;

            // Добавление события в список событий лога
            log.Events.Add(e);
        }

        return log; // Возврат заполненного лога
    }
}


/// <summary>
/// Пример использования XmlParser
/// </summary>
class Program
{
    static void Main()
    {
        // Пример XML-строки
        string xml = @"<log>
                          <event date=""2022-03-27 13:45:30"" result=""success"">
                            <ip-from>192.168.1.1</ip-from>
                            <method>GET</method>
                            <url-to>http://example.com</url-to>
                            <response>200</response>
                          </event>
                          <event date=""2022-03-27 14:15:20"" result=""error"">
                            <ip-from>192.168.1.2</ip-from>
                            <method>POST</method>
                            <url-to>http://example.com/api</url-to>
                            <response>404</response>
                          </event>
                        </log>";

        // Парсинг XML и создание объекта лога
        Log log = XmlParser.ParseXml(xml);

        // Вывод данных каждого события
        foreach (var e in log.Events)
        {
            Console.WriteLine($"Date: {e.Date}, Result: {e.Result}, IP: {e.IpFrom}, Method: {e.Method}, URL: {e.UrlTo}, Response: {e.Response}");
        }
    }
}