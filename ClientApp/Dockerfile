FROM node:latest as build

WORKDIR /usr/src/app

COPY package*.json ./

RUN npm install --silent

COPY . .

FROM node:latest

WORKDIR /usr/src/app

RUN npm i -g serve

RUN npm install --silent

COPY --from=build /usr/src/app/dist ./dist
COPY package.json .

EXPOSE 3006

CMD ["npm", "run-script", "start:prod"]