# Author: Jasper Schomaker
# Affiliation: University of Missouri
# College of Engineering
# College of Business
# August-December 2024
# Copyright © 2024 Jasper Schomaker. All rights reserved.

#homework_07   namespace = [library]

#creating the nested dictionary
all_books = {
    "1681376075": {
        "title": "The Netanyahus",
        "year": 2021,
        "author": "Joshua Cohen"
    },
    "0062671189": {
        "title": "The Night Watchman",
        "year": 2020,
        "author": "Louise Erdich"
    }
}

while True:
    #introduce the program
    print("Welcome to the library!")

    #prompt the user for input
    user_input = input("What would you like to do? Choose one from 'show', 'add', 'remove', or 'end': ")

    #if show
    if user_input == "show":
        for book_id, book_info in all_books.items():
            print(f"Book ID: {book_id}")
            print(f"Title: {book_info['title']}")
            print(f"Year: {book_info['year']}")
            print(f"Author: {book_info['author']}")
            print()

    #if add
    elif user_input == "add":
        new_book_id = input("Enter the ISBN: ")
        new_title = input("Enter the title of the new book: ")
        new_year = int(input("Enter the publication year of the new book: "))
        new_author = input("Enter the author of the new book: ")

        new_book_info = {
            "title": new_title,
            "year": new_year,
            "author": new_author
        }

        all_books[new_book_id] = new_book_info
        print("Book added successfully!")

    #if remove
    elif user_input == "remove":
        #prompt for ISBN number
        isbn_to_remove = input("Enter the ISBN of the book you want to remove: ")
        #check if keys exist in the dictionary
        if isbn_to_remove in all_books:
            removed_book = all_books.pop(isbn_to_remove)
            print("Removed book details:")
            print(removed_book)
        else:
            print(f"Book with ISBN {isbn_to_remove} not found.")

    #if end
    elif user_input == "end":
        print("Exiting the program.")
        break


