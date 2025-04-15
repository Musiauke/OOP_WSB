#zadanie 2

def get_number(prompt):
    while True:
        try:
            return int(input(prompt))
        except ValueError:
            print("Nie wprowadzono liczby. Spróbuj ponownie")


def convert_temperature(value, direction):
    if direction.lower() == "f":
        return (value*1.8)+32
    elif direction.lower() == "c":
        return (value - 32) / 1.8
    else:
        return None


def converter():

    print("Program pomaga w przeliczeniu temperatury")
    while True:
        choice = input("Jaki chcesz wybrać kierunek konwersji? Do °C czy °F? (Wpisz C lub F): ")
        if choice.lower() in ["c", "f"]:
            break
        else:
            print("Nieprawidłowy wybór. Spróbuj C lub F. ")
    
    input_temperature = get_number("Wprowadź temperaturę: ")    
    converted_temperature = convert_temperature(input_temperature, choice)

    if converted_temperature is not None:
        if choice.lower() == "f":
            print(f"{input_temperature}°C = {converted_temperature:.2f}°F")
        else:
            print(f"{input_temperature}°F = {converted_temperature:.2f}°C")
    else:
        print("Wystąpił błąd podczas konwersji temperatury ")
    


if __name__ == "__main__":
    converter()



