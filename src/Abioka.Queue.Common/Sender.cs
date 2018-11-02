using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Text;

namespace Abioka.Queue.Common
{
    public class Sender : ISender
    {
        private readonly IQueueConnection queueConnection;

        public Sender(IQueueConnection queueConnection) {
            this.queueConnection = queueConnection;
        }

        public void Send(string exchange, string routingKey, byte[] data) {
            using (var model = queueConnection.Connection.CreateModel()) {
                Send(model, exchange, routingKey, data);
            }
        }

        public void Send<T>(string exchange, string routingKey, T value) {
            var data = GetBytes(value);
            Send(exchange, routingKey, data);
        }

        public void Send<T>(string exchange, string routingKey, IEnumerable<T> value) {
            var datas = new List<byte[]>();
            foreach (var valueItem in value) {
                var data = GetBytes(valueItem);
                datas.Add(data);
            }

            using (var model = queueConnection.Connection.CreateModel()) {
                foreach (var dataItem in datas) {
                    Send(model, exchange, routingKey, dataItem);
                }
            }
        }

        private byte[] GetBytes(object value) {
            var message = JsonConvert.SerializeObject(value);
            return Encoding.UTF8.GetBytes(message);
        }

        private void Send(IModel model, string exchange, string routingKey, byte[] data) {
            var properties = model.CreateBasicProperties();
            properties.Persistent = true;

            model.BasicPublish(exchange, routingKey, properties, data);
        }
    }
}