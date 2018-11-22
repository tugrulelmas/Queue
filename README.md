[![Build Status](https://travis-ci.org/tugrulelmas/Queue.svg?branch=master)](https://travis-ci.org/tugrulelmas/Queue) 

# Queue
It's a basic repository which provides how you can publish and subscribe a message using RabbitMQ and Docker.

## Best Practises
* Use single instance of RabbitMQ connection.
* Use [work queues](https://www.rabbitmq.com/tutorials/tutorial-two-dotnet.html) to distribute tasks among workers.
* Set consumer `prefetchCount` as `1` to make RabbitMQ doesn't send a message to busy consumer instead of free one.
* Set `autoAck` as `false` and send a proper acknowledgment from the worker to be able to reconsume a message in case of any exception.
* Set `durable` of the queues as `true` to not lose the queue.
* Set `persistent` of the messages as `true` to not lose the message.
* Use `restart_policy` for the receiver in `docker-compose.yml` so that the receiver can try restart until the RabbitMQ is started.

## Docker Commands That Will Be Needed
### docker-compose
docker-compose up

docker-compose stop

docker-compose rm

### docker swarm
docker swarm init

docker stack deploy --compose-file docker-compose.yml queuestack
* If you have some problem with updating service you can use `--with-registry-auth` to solve the problem. Click [here](https://github.com/moby/moby/issues/34153) for more info. 

docker stack rm queuestack

docker stack services queuestack

docker ps -s
