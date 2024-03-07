# Author: Jasper Schomaker
# Affiliation: University of Missouri
# College of Engineering
# College of Business
# August-December 2024
# Copyright © 2024 Jasper Schomaker. All rights reserved.

class Item:
    def __init__(self, name="undefined", price=10.0, stock=0, discount=0.0, taxable=True):
        self.name = name
        self.price = price
        self.stock = stock
        self.discountP = discount
        self.taxable = taxable

    def get_name(self):
        return self.name

    def get_price(self):
        return self.price

    def get_stock(self):
        return self.stock

    def get_discount(self):
        return self.discountP

    def get_taxable(self):
        return self.taxable

    def set_name(self, name):
        self.name = name

    def set_price(self, price):
        self.price = price

    def set_stock(self, stock):
        self.stock = stock

    def set_discount(self, discount):
        self.discountP = discount

    def set_taxable(self, taxable):
        self.taxable = taxable

    def print_item(self):
        print("----- Information for", self.name, "-----")
        print("Price: ${:.2f}".format(self.price))
        print("Stock:", self.stock)
        print("Discount: {}%".format(self.discountP))
        print("Taxable:", self.taxable)
        print()

    def apply_discount(self):
        return self.price - self.price * self.discountP / 100


def read_items_from_file(file_name):
    try:
        with open(file_name, "r") as f:
            lines = f.readlines()

        all_items = []

        for line in lines:
            item_attributes = line.strip().split(',')
            name = item_attributes[0]
            price = float(item_attributes[1])
            stock = int(item_attributes[2])
            discount = float(item_attributes[3])
            taxable = item_attributes[4].strip().lower() == 'y'
            item = Item(name, price, stock, discount, taxable)
            all_items.append(item)

        return all_items

    except FileNotFoundError:
        print(f"Error: File '{file_name}' not found.")
        return []


def write_items_to_file(file_name, all_items):
    with open(file_name, "w") as updated_file:
        for item in all_items:
            updated_file.write("{},{},{},{},{}\n".format(item.get_name(), item.get_price(),
                                                          item.get_stock(), item.get_discount(),
                                                          'y' if item.get_taxable() else 'n'))


def display_items(items):
    for item in items:
        discounted_price = item.apply_discount()
        print("{}: Regular Price ${:.2f}, Discounted Price ${:.2f}".format(item.get_name(),
                                                                           item.get_price(),
                                                                           discounted_price))


def add_to_cart(cart, all_items):
    item_name = input("Enter the item name: ").capitalize()
    try:
        quantity = int(input("Enter the quantity: "))

        selected_item = next((item for item in all_items if item.get_name().lower() == item_name.lower()), None)

        if selected_item and selected_item.get_stock() >= quantity:
            if item_name in cart:
                cart[item_name] += quantity
            else:
                cart[item_name] = quantity

            print("{0} {1}(s) added to the cart.".format(quantity, item_name))
        else:
            print("Item not found or insufficient stock.")

    except ValueError:
        print("Invalid quantity input.")



def delete_from_cart(cart, all_items):
    item_name = input("Enter the item name: ").capitalize()
    try:
        quantity = int(input("Enter the quantity to delete: "))

        if item_name in cart and cart[item_name] >= quantity:
            cart[item_name] -= quantity
            print("{0} {1}(s) deleted from the cart.".format(quantity, item_name))
        else:
            print("Item not found in the cart or insufficient quantity.")

    except ValueError:
        print("Invalid quantity input.")


def display_cart(cart, all_items):
    total_price = 0
    for item_name, quantity in cart.items():
        selected_item = next((item for item in all_items if item.get_name().lower() == item_name.lower()), None)
        if selected_item:
            discounted_price = selected_item.apply_discount()
            item_total = discounted_price * quantity
            total_price += item_total
            print("{0}: {1} x ${2:.2f} = ${3:.2f}".format(item_name, quantity, discounted_price, item_total))

    sales_tax_rate = 4.225 / 100
    sales_tax = total_price * sales_tax_rate
    final_amount = total_price + sales_tax

    print("\nTotal Price: ${:.2f}".format(total_price))
    print("Sales Tax (4.225%): ${:.2f}".format(sales_tax))
    print("Final Amount: ${:.2f}".format(final_amount))

    return total_price, final_amount



def checkout(cart, all_items):
    total_price, final_amount = display_cart(cart, all_items)

    for item_name, quantity in cart.items():
        selected_item = next((item for item in all_items if item.get_name() == item_name), None)
        if selected_item:
            selected_item.set_stock(selected_item.get_stock() - quantity)

    #write the information of all items to items_info_updated.txt
    write_items_to_file("items_info_updated.txt", all_items)

    print("Checkout completed. Thank you for your purchase!")


def main():
    input_file = "items_info.txt"
    all_items = read_items_from_file(input_file)
    cart = {}

    while True:
        print("Options: show, add, delete, cart, check out, done")
        user_choice = input("What would you like to do? ").lower()

        if user_choice == "show":
            display_items(all_items)

        elif user_choice == "add":
            add_to_cart(cart, all_items)

        elif user_choice == "delete":
            delete_from_cart(cart, all_items)

        elif user_choice == "cart":
            display_cart(cart, all_items)

        elif user_choice == "check out":
            checkout(cart, all_items)
            break

        elif user_choice == "done":
            print("Thank you for using the program. Goodbye!")
            break

        else:
            print("Invalid option. Please choose one of the provided options.")


if __name__ == "__main__":
    main()
