FROM node:20
WORKDIR /app/postcss

COPY ./UsersCRUD.WebUI/wwwroot/package.json .
COPY ./UsersCRUD.WebUI/wwwroot/package-lock.json .
COPY ./UsersCRUD.WebUI/wwwroot/postcss.config.js .
COPY ./UsersCRUD.WebUI/wwwroot/tailwind.config.js .

RUN npm i

ENTRYPOINT npm run watch:tailwind
