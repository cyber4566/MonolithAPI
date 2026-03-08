# Monolith API

> Secure API that generates and uses **access tokens** and **refresh tokens** to authenticate and authorize users.

---

## Overview

Monolith API is a backend service that uses token-based authentication and authorization to validate users' access to endpoints.
It issues **access tokens** for API requests and **refresh tokens** to maintain user sessions when the access token expires. In addition, it supports **refresh token rotation** to provide an extra layer of security in the case of a refresh token theft.

---

## Features

* 🔐 Token-based authentication
* ♻️ Refresh token support
* 🛡️ User authentication and authorization
* ⚡ RESTful API structure

---

## Tech Stack

* Backend: .NET Core
* Authentication: JWT
* Database: MySQL

---

## Authentication Flow

1. User logs in with username and password.
2. API returns:

   * **Access Token** (short-lived)
   * **Refresh Token** (long-lived)
3. Access token is used to access protected endpoints. Access token also contains user roles for authorization.
4. When the access token expires, the refresh token is used to obtain a new access token and refresh token. The previous refresh token is deleted. 

---

## API Endpoints

### Authentication

| Method | Endpoint        | Description          |
| ------ | --------------- | -------------------- |
| POST   | `/auth/login`   | Authenticate user    |
| POST   | `/auth/refresh` | Refresh access token |
| POST   | `/auth/logout`  | Revoke refresh token |

---


