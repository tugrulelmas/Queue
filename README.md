[![Build Status](https://travis-ci.org/tugrulelmas/Queue.svg?branch=master)](https://travis-ci.org/tugrulelmas/Queue) 

# Queue

## docker-compose
docker-compose up
docker-compose stop
docker-compose rm

## docker swarm
docker swarm init
docker stack deploy --compose-file docker-compose.yml queuestack
docker stack rm queuestack

docker stack services queuestack
docker ps -s