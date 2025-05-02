# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Jade",
  "lastName": "Freel",
  "email": "jadefreeljd@gmail.com",
  "password": "Pa$$w0rd"
}
```

#### Register Response

```js
200 OK
```

```json
{
  "id": "7e0c3c59-ece7-4dd6-ac7b-481cfa565ba4",
  "firstName": "Jade",
  "lastName": "Freel",
  "email": "jadefreeljd@gmail.com",
  "token": "eyJhb...WmYGtk"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
  "email": "jadefreeljd@gmail.com",
  "password": "Pa$$w0rd"
}
```

#### Login Response

```js
200 OK
```

```json
{
  "id": "7e0c3c59-ece7-4dd6-ac7b-481cfa565ba4",
  "firstName": "Jade",
  "lastName": "Freel",
  "email": "jadefreeljd@gmail.com",
  "token": "eyJhb...WmYGtk"
}
```
