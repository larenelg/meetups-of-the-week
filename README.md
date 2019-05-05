# Data Driven Diversity

## Depedencies

* Docker (my settings: 6CPUs, 8GB RAM, 2GiB Swap)
* .NET Core SDK

## Run with production settings

The main ASP.NET Core MVC app depends on the following docker containers running:
* `ner` on `localhost:9000` - [Dockerfile for Stanford CoreNLP Server](https://hub.docker.com/r/frnkenstien/corenlp)
* `nlp` on `localhost:6000` - [Python Natural Language Toolkit Server](https://www.nltk.org/)
* `seq` (logging) on `localhost:5341` - [Seq](https://datalust.co/seq)

The command to run depedencies in docker is:
```
docker-compose up
```

## Developing locally

The main app is located in `./src/DataDrivenDiversity`

Make sure that your depedencies are running in docker:
* `seq`, `nlp`, `ner`

Then use

```
MEETUP_API_KEY=<your meetup api key> dotnet run
```

Then go to http://localhost:5000

NB: You can create/find your Meetup API key on https://secure.meetup.com/meetup_api/key/

To debug, you can run your app with your favourite IDE (I use Visual Studio Code), just make sure you set the following environmental variables in the launch settings:
* ASPNETCORE_ENVIRONMENT: `Development`
* MEETUP_API_KEY: `<your Meetup API key>`