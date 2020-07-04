# ZipApi

A very simple ASP .NET Core Api using Entitiy Framework with an sqlite database

## Installation

```bash
docker-compose up
```

Application is exposed over port 8080

## Usage

Get users HTTP GET
/api/users

Get account HTTP GET
/api/account

Add user HTTP POST
/api/users
```json
{
    "Email" : "john@test.com",
    "Address" : "1 Pitt St Sydney 2000",
    "MonthlySalary" : 9000,
    "MonthlyExpenses" : 1000
}
```

Add account HTTP POST
/api/accounts
```json
{
    "UserId" : 1
    "AccountLimit" : 1000
}
```
