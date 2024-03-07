# Author: Jasper Schomaker
# Affiliation: University of Missouri
# College of Engineering
# College of Business
# Date: August-December 2024
# Copyright © 2024 Jasper Schomaker. All rights reserved.


import turtle
import math

#screen
screen = turtle.Screen()
screen.bgcolor("black")
screen.title("recursionTurtleLineArt3.1")
screen.setup(width=1200, height=600)
#turn off automatic animation
screen.tracer(0)  

#inner circle
inner_turtle = turtle.Turtle()
inner_turtle.hideturtle()
inner_turtle.color("white")
inner_turtle.pensize(1)  
inner_turtle.penup()
inner_turtle.goto(0, -100)
inner_turtle.pendown()
inner_turtle.circle(100)
inner_turtle.penup()

#turtles for drawing
#n lines
num_turtles = 8
turtles = [turtle.Turtle() for _ in range(num_turtles)]

#even circular distribution
angles = [i * (360 / num_turtles) for i in range(num_turtles)]
speed = 2
size_increase = 0.1
line_color = "white"

for draw in turtles:
    draw.speed(0)
    draw.pensize(1)
    draw.color(line_color)
    draw.hideturtle()

#function to draw
def draw_expanding_rotating_lines(rotation):
    #gradual increase
    a = 200 + rotation * size_increase
    b = 100 + rotation * size_increase
    for i, draw in enumerate(turtles):
        angle = angles[i]
        
        #calculate position
        x = a * math.cos(math.radians(angle)) * math.cos(math.radians(rotation)) - b * math.sin(math.radians(angle)) * math.sin(math.radians(rotation))
        y = a * math.cos(math.radians(angle)) * math.sin(math.radians(rotation)) + b * math.sin(math.radians(angle)) * math.cos(math.radians(rotation))

        #lift pen to position turtles
        if rotation == 0:  
            draw.penup()
            draw.goto(x, y)
            draw.pendown()
        #continuous lines
        else:
            draw.goto(x, y)  
        
        #update angle
        angles[i] = (angle + speed) % 360

#drawing loop
#set rotation
rotation = 0  
while True:
    draw_expanding_rotating_lines(rotation)
    #increment rotation
    rotation += 1  
    screen.update()
    #delay drawing speed
    turtle.delay(10)  
