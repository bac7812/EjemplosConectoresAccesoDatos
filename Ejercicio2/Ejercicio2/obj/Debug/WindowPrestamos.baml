   M S B A M L   `   `   `  ����E  AEjercicio2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ejercicio2
Ejercicio2  5   	        Ejercicio2.WindowPrestamos   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Ejercicio2     5   	   -   5          �Name$  prestamosWindow��5   	    � Title$  Mantenimiento de prestamos��5   	   $	��460��6,   $	��460��69    � 
ResizeMode$ NoResize=�6E   .��5	      � $��10q�6    � ColumnDefinitions 5
   
   �� 5      $��80 �6   6,   �� 5      $	��130 �6   6-   �� 5      6!    � RowDefinitions 5   
   �� 5      $��35 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $	��170 �6   6+   �� 5      $��40 �6   6*   .+�5   
   �� -   5         ��Name$ buscarLabel��5      $��Buscar por:��6%   $
��Left=�6;   $��27��6V   $��5q�6b   $	��Top=�6m   $	��126��6�   $��0��6�   $��0��6�   �� 5   
   -   5        $ buscarSocioLabel��5      $��Socio:��6*   $��Right=�6;   $��27��6W   $��5q�6c   $	��Top=�6n   $��45��6�   $��0��6�   $��1��6�   �� 5   
   -   5         ��Name$ busquedaSocioComboBox��5      $��Right=�62   $��5q�6N   $	��Top=�6Y   $	��120��6q   $��1��6}   $��1��6�   5      �� 5   
   -   5         ��Name$ busquedaSocioTextBox��5      $
��Left=�60   $��23��6K   $��5q�6W    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��200��6�   $��2��6�   $��1��6�   �� 5!   
   -   5        $ buscarLibroLabel��5!      $��Libro:��6*   $��Right=�6;   $��27��6W   $��5q�6c   $	��Top=�6n   $��45��6�   $��0��6�   $��2��6�   �� 5"   
   -   5        $ busquedaLibroComboBox��5"      $��Right=�62   $��5q�6N   $	��Top=�6Y   $	��120��6q   $��1��6}   $��2��6�   5$      �� 5%   
   -   5        $ busquedaLibroTextBox��5%      $
��Left=�60   $��23��6K   $��5q�6W   $
 Wrap=�6b   $	��Top=�6v   $	��200��6�   $��2��6�   $��2��6�   � 5'   
   $��0��6   $��3��6$   $��3��68   	 � Orientation$	 
Horizontal=�6E   $��Center=�6^   .+�5(      �� -	   5        
 ��Name$
 registrarButton��5(      $��	Registrar��6.   $��Center=�6B   $��5q�6_   $��Center=�6j   $��80��6�   $��22��6�   6�   �� 5)      -
   5        $
 devolverButton��5)      $��Devolver��6-   $��Center=�6@   $��5q�6]   $��Center=�6h   $��80��6�   $��22��6�   6�   5*      �� 5,   
   -   5        $ ejemplaresLabel��5,      $��Ejemplares:��6)   $
��Left=�6?   $��5q�6Z   $��Bottom=�6e   $��0��6�   $��4��6�   &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ ejemplaresDataGrid��5-      $
��Left=�6/   $	��160��6J   $��5q�6W   $	��Top=�6b   $	��410��6z   $��0��6�   $��3��6�   $��5��6�   {�.     AutoGenerateColumns .     Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ Código��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *CodigoLibro+  50      $ Nº Ejemplares��6%    6<   �� *NumeroEjemplar+  51      $ Fecha��6%    64   �� *FechaPublicacion+  52      $ Estado��6%    65   �� *Estado+54      � 56   
   $��0��6   $��3��6$   $��6��68   $	 
Horizontal=�6E   $��Center=�6^   .+�57      �� -   5        $
 actualizarButton��57      $��
Actualizar��6/   $��Center=�6D   $��5q�6a   $	��Top=�6l   $��80��6�   $��22��6�   {�.  6�   �� 58      -   5        $
 cancelarButton��58      $��Cancelar��6-   $��Center=�6@   $��5q�6]   $	��Top=�6h   $��80��6�   $��22��6�   {�.  6�   59      5;      5<      