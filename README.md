# WordWave
### WordWave is built using .NET Core (mvc) version 6.0.
### Try <a href="https://wordwave-uyv9.onrender.com">WordWave</a> Now.
## Run a migration first
enable-migrations<br/>
add-migration "migration_name_can_be_given_any"<br/>
## Update Database
update-database
## Want a quick spin up?
### Docker is to the rescue. WordWave is dockerized. Just follow the quick and easy steps provided below:
#### 1. Install <a href='https://docs.docker.com/engine/install/'>Docker</a>
#### 2. Now pull <code>dm2903/wordwave:latest</code> image from dockerhub
```sh
docker pull dm2903/wordwave
```
#### 3. Now just run the container and provide the essential <code>Environment variables</code>
```sh
docker run --env=ASPNETCORE_LOGGING__CONSOLE__DISABLECOLORS=true --env=ASPNETCORE_ENVIRONMENT=Development --env=DOTNET_USE_POLLING_FILE_WATCHER=1 --env=NUGET_PACKAGES=/.nuget/fallbackpackages --env=NUGET_FALLBACK_PACKAGES=/.nuget/fallbackpackages --env=PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin --env=ASPNETCORE_URLS=http://+:80 --env=DOTNET_RUNNING_IN_CONTAINER=true --env=DOTNET_VERSION=6.0.31 --env=ASPNET_VERSION=6.0.31 --env=Server= --env=Database= --env=User= --env=Password= -t -p 8080:80 dm2903/wordwave:latest
```
#### Now, the webapp should be running at http://localhost:8080/
