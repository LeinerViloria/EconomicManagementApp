# EconomicManagementApp

#Los operations types no se pueden manejar, sólo obtener desde la base de datos,
#en el script de la bd está esa inserción

#En caso de que quiera borrar tipos de cuentas o cuentas, si un tipo de cuenta tiene cuentas,
#o si una cuenta tiene transacciones, no se borrarán de la base de datos, simplemente se
#desactivarán para que siga habiendo consistencia de datos; en caso contrario de cualquiera de esos
#dos casos, sí se borrarán de la base de datos.