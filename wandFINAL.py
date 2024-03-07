#class name
#class class_name:
class Wands:
    info_printed = False
    #class atrributes
    #properties of objects
    #must assign default value to each attribute
    #attribute_name = default_value
    Length = 0
    Wood = "undefined"
    Core = "undefined"
    Owner = "undefined"

    #Initializer/Constructor function
    def __init__(self, L, W, C, O):
        self.Length = L
        self.Wood = W
        self.Core = C
        self.Owner = O
        
    def print_wand(self):
        if not Wands.info_printed:
            print("----- Information for Known Wands -----")
            print("")
            Wands.info_printed = True  

        print("Length:", self.Length)
        print("Wood:", self.Wood)
        print("Core:", self.Core)
        print("Owner:", self.Owner)
        print("")
        

wand1 = Wands("15 Inches", "Elder Wood", "Thestral Hair", "Albus Dumbeldore")
wand2 = Wands("12 & 3/4 Inches", "Walnut", "Dragon Heartstring", "Bellatrix Lestrange")
wand3 = Wands("12 & 1/4 Inches", "Ash", "Unicorn Hair", "Cedric Diggory")
wand4 = Wands("10 Inches", "Hawthorne", "Unicorn Hair", "Draco Malfoy")

wand1.print_wand()
wand2.print_wand()
wand3.print_wand()
wand4.print_wand()

