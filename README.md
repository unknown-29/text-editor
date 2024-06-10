# word-wave
WordWave is a cutting-edge online document creation and editing platform that completely transforms how you deal with text and content. Built with the robust .NET Core framework and powered by the versatile TinyMCE editor, WordWave offers a seamless and feature-rich experience for all your document needs.

With WordWave, you can effortlessly create, edit, and collaborate on documents from anywhere with an internet connection. Whether you're working on important reports, collaborative projects, or creative writing, WordWave empowers you with an array of powerful tools and features, making your document management a breeze.

### Try <a href="https://wordwave-uyv9.onrender.com">WordWave</a> Now.

* tech stack : .NET Core mvc (v6.0)
* demo video : https://youtu.be/FdUhGBDrSYw?feature=shared
  # Preview

<img src="https://github.com/unknown-29/word-wave/assets/107257619/3c9b29aa-1c04-4a3e-b265-8c7f208317e9" width=65%/>
<img src="https://github.com/unknown-29/word-wave/assets/107257619/55101aa0-dd27-4f26-8803-6108132eba91" width=65%/>
<img src="https://github.com/unknown-29/word-wave/assets/107257619/52d1a8e3-06cf-4566-92e1-9687ee57d34f" width=65%/>
<img src="https://github.com/unknown-29/word-wave/assets/107257619/9ec6038f-1422-49f7-a5d2-338ed6180047" width=65%/>
<img src="https://github.com/unknown-29/word-wave/assets/107257619/4df744bf-5181-4341-83ad-27211ede0523" width=65%/>

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
