
import requests
import random

API_URL = "http://localhost:5000/api/quotes"

def fetch_quotes():
    """ Fetch all quotes from the API and display them. """
    response = requests.get(API_URL)
    if response.status_code == 200:
        quotes = response.json()
        if not quotes:
            print("\nNo quotes available.\n")
        else:
            print("\n--- Quotes ---")
            for q in quotes:
                print(f"{q['Id']}: \"{q['Text']}\" - {q['Author']} ({q['Likes']} Likes)")
                print(f"Tags: {', '.join([t['Name'] for t in q['Tags']]) if q['Tags'] else 'No tags'}")
                print("-" * 30)
    else:
        print("\nFailed to fetch quotes. API might be down.")

def add_quote():
    """ Add a new quote via the API. """
    text = input("Enter quote: ").strip()
    author = input("Enter author: ").strip()
    if not text:
        print("Quote cannot be empty!")
        return

    response = requests.post(API_URL, json={"Text": text, "Author": author})
    if response.status_code == 201:
        print("\nâœ… Quote added successfully!\n")
    else:
        print("\nâŒ Failed to add quote.\n")

def like_quote():
    """ Like a quote by ID. """
    quote_id = input("Enter Quote ID to like: ").strip()
    if not quote_id.isdigit():
        print("Invalid ID!")
        return

    response = requests.put(f"{API_URL}/{quote_id}/like")
    if response.status_code == 200:
        print("\nâ¤ï¸ Quote liked!\n")
    else:
        print("\nâŒ Quote not found.\n")

def assign_tag():
    """ Assign a tag to a quote. """
    quote_id = input("Enter Quote ID to tag: ").strip()
    tag = input("Enter tag: ").strip()
    if not quote_id.isdigit() or not tag:
        print("Invalid input!")
        return

    response = requests.post(f"{API_URL}/{quote_id}/tags", json={"Name": tag})
    if response.status_code == 200:
        print("\nðŸ· Tag assigned successfully!\n")
    else:
        print("\nâŒ Failed to assign tag. Quote might not exist.\n")

def get_random_quote():
    """ Fetch a random quote from the API. """
    response = requests.get(API_URL)
    if response.status_code == 200:
        quotes = response.json()
        if quotes:
            quote = random.choice(quotes)
            print(f"\nðŸŽ² Random Quote: \"{quote['Text']}\" - {quote['Author']} ({quote['Likes']} Likes)\n")
        else:
            print("\nNo quotes available.\n")
    else:
        print("\nFailed to fetch quotes.\n")

def main():
    """ Command-line interface for the quotes application. """
    while True:
        print("\n--- Quote Manager ---")
        print("1. View Quotes")
        print("2. Add Quote")
        print("3. Like a Quote")
        print("4. Assign Tag to Quote")
        print("5. Get Random Quote")
        print("6. Exit")
        choice = input("\nEnter choice: ").strip()

        if choice == "1":
            fetch_quotes()
        elif choice == "2":
            add_quote()
        elif choice == "3":
            like_quote()
        elif choice == "4":
            assign_tag()
        elif choice == "5":
            get_random_quote()
        elif choice == "6":
            print("\nGoodbye! ðŸ‘‹")
            break
        else:
            print("\nInvalid choice. Please try again.\n")

if __name__ == "__main__":
    main()
