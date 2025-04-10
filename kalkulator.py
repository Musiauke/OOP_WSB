#zadanie 1

def get_number(prompt):
    while True:
        try:
            return float(input(prompt))
        except ValueError:
            print("Nie wprowadzono liczby. Spróbuj ponownie")


def calculator():
    a = get_number(("Podaj proszę piewszą liczbę: "))
    b = get_number(("Podaj proszę drugą liczbę: "))
   
    operation = input("Jaką operację chcesz wykonać? (wybierz +,-,*,/)")

    if operation == "+":
        print(f"Wynik: {a + b}")
    elif operation == "-":
        print(f"Wynik: {a - b}")
    elif operation == "*":
        print(f"Wynik: {a * b}")
    elif operation == "/":
        if b != 0:
            print(f"Wynik: {a / b}")
        else:
            print("Operacja niewykonalna")
    else:
        print("Wybrano nieprawną operację, spróbuj ponownie")

if __name__ == "__main__":
    calculator()
