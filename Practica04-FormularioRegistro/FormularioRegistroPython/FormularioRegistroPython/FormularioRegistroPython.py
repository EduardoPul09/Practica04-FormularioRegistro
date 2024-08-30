#3O LIDTS - EduardoPulido - 04Python
#Formulario de registro


import tkinter as tk
from tkinter import messagebox



def limpiar():
    tbNombres.delete(0,tk.END)
    tbApellidos.delete(0,tk.END)
    tbEdad.delete(0,tk.END)
    tbEstatura.delete(0,tk.END)
    tbTelefono.delete(0,tk.END)
    var_genero.set(0)
def borrar_fun():
    limpiar()


def guardar():
    nombres=tbNombres.get()
    apellidos=tbApellidos.get()
    edad = tbEdad.get()
    estatura = tbEstatura.get()
    telefono = tbTelefono.get()
    genero =""
    if var_genero.get()==1:
        genero = "Hombre"
    elif var_genero.get()==2:
        genero = "Mujer"
    datos = "Nombre: "+nombres+"\nApellidos: "+apellidos+"\nEdad: "+edad+ "\nEstatura: "+estatura+"\nTelefono: "+telefono+"\nGenero: "+genero
    with open("datosP.txt","a") as file:
        file.write(datos + "\n\n")
    messagebox.showinfo("Datos "+"Datos guardados: \n\n", datos)

ventana = tk.Tk()
ventana.geometry("520x500")
ventana.title("Formulario Python")

var_genero = tk.IntVar()

lbNombres = tk.Label(ventana, text = "Nombres: ")
lbNombres.pack()
tbNombres = tk.Entry()
tbNombres.pack()
lbApellidos = tk.Label(ventana, text = "Apellidos: ")
lbApellidos.pack()
tbApellidos = tk.Entry()
tbApellidos.pack()
lbTelefono = tk.Label(ventana, text = "Telefono: ")
lbTelefono.pack()
tbTelefono = tk.Entry()
tbTelefono.pack()
lbEdad = tk.Label(ventana, text = "Edad: ")
lbEdad.pack()
tbEdad = tk.Entry()
tbEdad.pack()
lbEstatura = tk.Label(ventana, text = "Estatura: ")
lbEstatura.pack()
tbEstatura = tk.Entry()
tbEstatura.pack()
lbGenero = tk.Label(ventana, text = "Genero ")
lbGenero.pack()
rbHombre = tk.RadioButton(ventana, text = "Hombre", variable=var_genero, value=1)
rbHombre.pack()
rbMujer = tk.RadioButton(ventana, text = "Mujer", variable=var_genero, value=2)
rbMujer.pack()
bBorrar = tk.Button(ventana, text = "Borrar", command=borrar_fun)
bBorrar.pack()
bGuardar = tk.Button(ventana, text = "Guardar", command=guardar)
bGuardar.pack()

ventana.mainloop

