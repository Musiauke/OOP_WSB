#zadanie 3

def get_number(prompt):
    while True:
        try:
            return int(input(prompt))
        except ValueError:
            print("Nie wprowadzono liczby. Spróbuj ponownie")

def get_grades(count):
    grades = []
    for i in range(count):
        while True:
            grade = get_number(f"Podaj ocenę {i + 1} (1-6): ")
            if 1 <= grade <= 6:
                grades.append(grade)
                break
            else:
                print("Ocena musi być w zakresie od 1 do 6")
    return grades

def calculate_average(grades):
    return sum(grades) / len(grades)

def check_pass(avg):
    if avg >= 3.0:
        print(f"Uczeń zdał. \n Średnia to: {avg:.2f}")
    else:
        print(f"Uczeń nie zdał. \n Średnia to: {avg:.2f}")

def grade_point_average_program():
    print("Program pomaga w obliczeniu średniej ocen")
    count = get_number("Ile ocen chcesz wprowadzić?: ")
    user_grades = get_grades(count)
    avg = calculate_average(user_grades)
    check_pass(avg)

if __name__ == "__main__":
    grade_point_average_program()



