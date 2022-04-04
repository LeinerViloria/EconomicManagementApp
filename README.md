# EconomicManagementApp

Los operations types no se pueden manejar, sólo obtener desde la base de datos,
en el script de la bd está esa inserción

En caso de que quiera borrar tipos de cuentas o cuentas, si un tipo de cuenta tiene cuentas,
o si una cuenta tiene transacciones, no se borrarán de la base de datos, simplemente se
desactivarán para que siga habiendo consistencia de datos; en caso contrario de cualquiera de esos
dos casos, sí se borrarán de la base de datos.

Vista de login

![Evidencia 1](https://user-images.githubusercontent.com/88936718/161612635-082ef90d-0470-4fc8-9953-c07e85e57a9c.png)

Esto es lo primero que ve un usuario que se acaba de registrar

![Evidencia 4](https://user-images.githubusercontent.com/88936718/161612953-91f84768-f247-4009-bd8b-178741612f9b.png)

Esto es lo que ve un usuario cuando tiene informacion en la aplicación

![Evidencia 2](https://user-images.githubusercontent.com/88936718/161612767-6d9126ab-2119-495f-95a2-2ef74f9221df.png)

Esta es la vista de las ultimas 10 transacciones (se pueden ver por Account o generalmente)

![Evidencia 3](https://user-images.githubusercontent.com/88936718/161612801-b3c26ca4-23d4-4484-967d-b7fc9376891d.png)

