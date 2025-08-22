# ATEA Billing API

## Features

- **User Authentication:** Login endpoint for user authentication.
- **Order Processing:** Submit orders specifying payment gateway (PayPal or Stripe).
- **Payment Gateways:** Mock gateways with different behaviors (PayPal always succeeds, Stripe always fails).
- **Order History:** Endpoint to retrieve a users previous orders and receipts.
- **Swagger UI:** Interactive testing.

## Getting Started

1. **Clone the repository:**
    ```bash
    git clone https://github.com/matuksd/Atea
    cd Atea
    ```

2. **Restore dependencies:**
    ```bash
    dotnet restore
    ```

3. **Run the API:**
    ```bash
    dotnet run --project Atea
    ```

4. **Access Swagger UI:**
    - Navigate to your locahlost:####/swagger

## API Endpoints

- `POST /api/auth/login`  
  Authenticate user.  
  **Body:**  
  ```json
  {
    "username": "atea",
    "password": "password"
  }
  ```

- `POST /api/order/process`  
  Process an order.  
  **Body:**  
  ```json
  {
    "orderNumber": "ORDER - 12345",
    "userId": 1,
    "payableAmount": 100.0,
    "paymentGateway": "PayPal",
    "description": "Order for #12345"
  }
  ```

- `GET /api/order/history/{userId}`  
  Get all previous orders for a user.

## Running Unit Tests

1. **Navigate to the test project folder:**
    ```bash
    cd Atea.Tests
    ```

2. **Run the tests:**
    ```bash
    dotnet test
    ```
