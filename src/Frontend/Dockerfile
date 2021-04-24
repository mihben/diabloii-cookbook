# FROM arm32v7/node as build-stage - If want to build to ARM, like raspberry
FROM node:14-alpine as builder
COPY ./src/Frontend/package.json ./

RUN npm i && mkdir /app && mv ./node_modules ./app
WORKDIR /app
COPY ./Frontend/ .
RUN $(npm bin)/ng build --prod --output-path=dist

FROM nginx:1.15.8-alpine
COPY nginx.conf /etc/nginx/
RUN rm -rf /usr/share/nginx/html/*

COPY --from=builder /app/dist /usr/share/nginx/html
CMD ["nginx", "-g", "daemon off;"]