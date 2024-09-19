FROM node:20
WORKDIR /styles/UsersCRUD.WebUI/postcss

COPY ./UsersCRUD.WebUI/wwwroot/package.json .
COPY ./UsersCRUD.WebUI/wwwroot/package-lock.json .
COPY ./UsersCRUD.WebUI/wwwroot/postcss.config.js .
COPY ./UsersCRUD.WebUI/wwwroot/tailwind.config.js .

RUN npm i

ENTRYPOINT ls -a && ls ../wwwroot -a && ls -a ../wwwroot/css && node_modules/.bin/tailwindcss -h && node_modules/.bin/tailwindcss --watch=always -i ../wwwroot/css/main.css -o ../wwwroot/lib/main.css
