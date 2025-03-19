# Event-Driven Architecture Trading Platform

This project demonstrates how event-driven architecture can be utilized for complex workflows, asynchronous processing, and Command Query Responsibility Segregation (CQRS). It is designed to showcase the power of event-driven systems in handling trading operations efficiently.

## Overview

The platform is built using .NET and leverages the MediatR library to implement the mediator pattern. This allows for decoupled communication between components, making the system more maintainable and scalable. The project is structured to handle trading operations through events and commands, ensuring a clear separation of concerns.

### Key Features

- **Event-Driven Architecture**: The system is designed around events, enabling asynchronous processing and better scalability.
- **CQRS**: Commands and queries are segregated to provide a clear distinction between write and read operations.
- **MediatR Integration**: MediatR is used to handle commands and queries, promoting a clean and decoupled architecture.

## Project Structure

The project is organized into the following key components:

- **Controllers**: Handle HTTP requests and route them to the appropriate handlers.
- **Handlers**: Contain the business logic for processing commands and queries. These are further divided into `Order` and `Trade` domains.
  - **Commands**: Handle operations that modify the state of the system.
  - **Queries**: Handle operations that retrieve data without modifying the state.
- **Events**: Define the events that drive the system's workflows.

## How It Works

1. **Event Handling**: Events are triggered based on specific actions, such as placing an order or executing a trade.
2. **Command Processing**: Commands are processed by their respective handlers, which contain the business logic.
3. **Query Execution**: Queries are handled separately to retrieve data without affecting the system's state.

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Docker (optional, for containerized deployment)

### Running the Application

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/event-driven-architecture-trading-platform.git
   ```
2. Navigate to the project directory:
   ```bash
   cd event-driven-architecture-trading-platform
   ```
3. Build and run the application:
   ```bash
   dotnet run --project EventDrivenTradingPlatform/EventDrivenTradingPlatform.csproj
   ```

### Using Docker

1. Build the Docker image:
   ```bash
   docker-compose build
   ```
2. Run the application:
   ```bash
   docker-compose up
   ```

## Technologies Used

- **.NET 8.0**: The core framework for building the application.
- **MediatR**: For implementing the mediator pattern.
- **MongoDB**: As the database for storing trading data.
- **Swagger**: For API documentation.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.