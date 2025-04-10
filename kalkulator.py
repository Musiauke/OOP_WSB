#zadanie 1

def calculator():
    a = float(input("Podaj proszę piewszą liczbę: "))
    b = float(input("Podaj proszę drugą liczbę: "))
    operation = input("Jaką operację chcesz wykonać? (wybierz +,=,*,/)")

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
            print
    else:
        print("Wybrano nieprawną operację, spróbuj ponownie")

if __name__ == "__main__":
    calculator()
