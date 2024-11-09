# Produto Management System

A simple C# application to manage product stock, including setting and retrieving information, calculating available quantities, and handling stock adjustments.

## Features

This project defines a `Produto` class with the following features:

- **Properties**: 
  - `IdProd`: Unique identifier for the product.
  - `Designacao`: Name or designation of the product.
  - `QtdStock`: Quantity of product in stock.
  - `StockSeg`: Safety stock level, or minimum stock before restocking is necessary.

- **Constructors**:
  - Default constructor setting `Designacao` to `"Produto XPTO"`.
  - Constructor initializing `QtdStock` with a default value.
  - Constructor initializing both `Designacao` and `QtdStock`.

- **Methods**:
  - `CalcularQuantidadeDisponivel()`: Calculates available stock by subtracting safety stock (`StockSeg`) from the total stock (`QtdStock`).
  - `LevantarProduto(int quantidade)`: Removes a specified quantity from stock if available, issues a warning if stock is below safety levels, and prevents invalid removals.

## Installation

1. Clone the repository.
   ```bash
   git clone https://github.com/yourusername/product-management.git
   ```
2. Open the project in Visual Studio or another C# IDE.

## Usage

1. Build and run the program.
2. Input the product’s information when prompted:
   - **ID**: A unique identifier for the product.
   - **Designation**: Name of the product.
   - **StockSeg**: Safety stock level.
3. The program displays the product information and calculates the available quantity.
4. You can then enter an amount to "withdraw" from the stock, and the program will update the stock and indicate if restocking is needed.

## Example

```plaintext
Insira o ID do produto: 1
Insira a designacão: Produto ABC
Insira a quantidade do stock de segurança: 10

Informações do Produto:
IdProd: 1
Designacao: Produto ABC
QtdStock: 120
StockSeg: 10
Quantidade Disponível: 110

Insira a quantidade a levantar do produto: 20
OK! 20 levantada. Stock restante: 100
```

If the available stock drops below the safety level after a withdrawal, it will notify you to restock.

## Error Handling

- Throws errors for invalid values in `IdProd`, `Designacao`, `QtdStock`, and `StockSeg`.
- Handles invalid inputs gracefully with exception messages.

