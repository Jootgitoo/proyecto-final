   M S B A M L   `   `   `  ����E  AzeroGluten, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:zeroGluten.viewzeroGluten.view  5          zeroGluten.view.Registro   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:zeroGluten.view     5        � Title$  Registro��5      $	��720��6   $
��1200��6%    � Cursor$  ��62    � 
ResizeMode$ NoResize=�5	       � WindowStartupLocation$ CenterScreen=�5
      
������  � AllowsTransparency$
 True��5       � WindowStyle$
 None=�5      .��5      � .+�5   
   (� .��5      � $	��799��6   $	��430��6   ���#D9C5B4.+�5      �� $��/images/logo-app.png��6   $
��Left=�66   $	��430��6Q   $��Center=�6^   $	��436��6y   ${�False��6�   �� 5      $
��Left=�6   $��
453,11,0,0q�67   ���#400101$
��Wrap=�6`   $��FORMULARIO DE REGISTRO��6t   $��30(�6�   $	��Top=�6�   $��32��6�   $	��296��6�   $*��$pack://application:,,,/font/#Maxwell)�6�   $
��Bold"�6  �� 5      $��436,64,0,68q�6   .��5      �� .+�5      �� $��Nombre:��6$   $*��$pack://application:,,,/font/#Maxwell)�63   $
��Bold"�6e   �� 5      -   5        $��tbNombre��5   "   $��0 0 0 10q�62   $*��$pack://application:,,,/font/#Maxwell)�6D   �� 5       $��Primer apellido:��6$   $*��$pack://application:,,,/font/#Maxwell)�6<   $
��Bold"�6n   �� 5!      -   5         ��Name$ 
tbApellido��5!   "   $��0 0 0 10q�66   $*��$pack://application:,,,/font/#Maxwell)�6H   �� 5#      $��Email:��6$   $*��$pack://application:,,,/font/#Maxwell)�62   $
��Bold"�6d   �� 5$      -   5        $��tbEmail��5$   "   $��0 0 0 10q�61   $*��$pack://application:,,,/font/#Maxwell)�6C   �� 5&      $��Contraseña:��6$   $*��$pack://application:,,,/font/#Maxwell)�67   $
��Bold"�6i   �� 5'      -   5        $ 
tbPassword��5'   "   $��0 0 0 10q�66   $*��$pack://application:,,,/font/#Maxwell)�6H   �� 5)      $��Fecha de nacimiento:��6$   $*��$pack://application:,,,/font/#Maxwell)�6@   $
��Bold"�6r   (  "System.Windows.Controls.DatePicker  5*      -   5        $��dpFechaNacimiento��5*   %   6@   �� 5,      $$��Con que género se identifica:��6$   $*��$pack://application:,,,/font/#Maxwell)�6I   $
��Bold"�6{   �� 5-      -   5        $��cbGenero��5-   #   $*��$pack://application:,,,/font/#Maxwell)�63   $
��Bold"�6e   5/      �� 51      $��Seleccione su peso:��6$   $*��$pack://application:,,,/font/#Maxwell)�6?   $
��Bold"�6q   �� 52      -   5        $��cbPeso��52   #   $*��$pack://application:,,,/font/#Maxwell)�61   $
��Bold"�6c   54      �� 56      $��Seleccione su altura:��6$   $*��$pack://application:,,,/font/#Maxwell)�6A   $
��Bold"�6s   �� 57      -   5        $��cbAltura��57   #   $*��$pack://application:,,,/font/#Maxwell)�63   $
��Bold"�6e   59      �� 5;      $.��(Realizas actividad física regularmente:��6$   $*��$pack://application:,,,/font/#Maxwell)�6S   $
��Bold"�6�   �� 5<      -	   5        $��cbActividadFisica��5<   #   $*��$pack://application:,,,/font/#Maxwell)�6<   $
��Bold"�6n   5>      �� 5@      $#��Con que frecuencia: (semanal)��6$   $*��$pack://application:,,,/font/#Maxwell)�6I   $
��Bold"�6{   �� 5A      -
   5        $!��cbFrecuenciaActividadFisica��5A   #   $*��$pack://application:,,,/font/#Maxwell)�6F   $
��Bold"�6x   5C      �� 5E      $$��Condiciones médicas conocidas��6$   $*��$pack://application:,,,/font/#Maxwell)�6I   $
��Bold"�6{   �� 5F      -   5        $��cbCondicionMedica��5F   #   $*��$pack://application:,,,/font/#Maxwell)�6<   $
��Bold"�6n   5H      �� 5J      $*��$Tomas medicamentos de forma continua��6$   $*��$pack://application:,,,/font/#Maxwell)�6P   $
��Bold"�6�   �� 5K      -   5        $��cbTomasMedicamentos��5K   #   $*��$pack://application:,,,/font/#Maxwell)�6>   $
��Bold"�6p   5M      �� 5O      $:��4Del 1 al 10 que puntuación le das a tu alimentacion��6$   $*��$pack://application:,,,/font/#Maxwell)�6_   $
��Bold"�6�   �� 5P      -   5        $��cbNotaDieta��5P   #   $*��$pack://application:,,,/font/#Maxwell)�66   $
��Bold"�6i   5R      �� 5T      $��Eres fumador��6$   $*��$pack://application:,,,/font/#Maxwell)�68   $
��Bold"�6j   �� 5U      -   5        $��	cbFumador��5U   #   $*��$pack://application:,,,/font/#Maxwell)�64   $
��Bold"�6g   5W      �� 5Y      $I��CFamiliares con enfermedades relacionadas con el peso o metabolistmo��6$   $*��$pack://application:,,,/font/#Maxwell)�6o   $
��Bold"�6�   �� 5Z      -   5        $��cbEnfermedades��5Z   #   $*��$pack://application:,,,/font/#Maxwell)�69   $
��Bold"�6l   5\      �� 5]      $M��GQue enfermedades tienes diagnosticadas en relación con la alimentacion��6$   $*��$pack://application:,,,/font/#Maxwell)�6r   $
��Bold"�6�   �� 5^      -   5        $ ��cbEnfermedadesAlimenticias��5^   #   $*��$pack://application:,,,/font/#Maxwell)�6E   $
��Bold"�6x   5`      �� 5b      $A��;Cuál de las siguientes opciones se parecen más a tu dieta��6$   $*��$pack://application:,,,/font/#Maxwell)�6e   $
��Bold"�6�   �� 5c      -   5        $��cbDietas��5c   #   $*��$pack://application:,,,/font/#Maxwell)�63   $
��Bold"�6f   5e      5h      5i      �� 5l      -   5        $��
btnDarAlta��5l      $��Dar de alta��6+   $
��Left=�6A   $��679,391,0,0q�6\   $	��Top=�6q   $��29��6�   $	��110��6�   ���#400101���#DEDEDE$*��$pack://application:,,,/font/#Maxwell)�6�   $
��Bold"�6�   6  �� 5o      -   5         ��Name$ btnMinimizar��5o      $��-��6/   $��20��6<   $��20��6G   $
��Left=�6S   $��	754,1,0,0q�6n   $	��Top=�6�   ��5p      �� 5r       �� 
TargetType" ��6    .�5s      �� 	 �� Property	 � ��
 �� Value

 ���� 6;   �� 5t      	 � ��

 �����6;   �� 5u      	 � ��

 ���� 6<   �� 5v      	 � ��$
 0q�6@   �� 5w      	 � ��
 5x   "   �� 5y   &    �� 
TargetType" ��66   .R�5z   *   ��  ��Name$ border��61   #��z��6A    �� CornerRadius$
 17.5��6l   ._�5{   .   �� $��Center=�6?   $��Center=�6\   5|   +    �� Triggers 5}   *   P� 5   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �5�   2   ��  �� 
TargetName$ border��69   	 � ��

 �����6c   �� 5�   2   	 � ��

 �   �6O   5�   /   5�   '   5�      5�      5�      �� 5�      -   5        $��	btnCerrar��5�      $��X��6*   $��20��68   $��20��6C   $
��Left=�6O   $��	779,1,0,0q�6j   $	��Top=�6}   ��5�      �� 5�      " ��6    .�5�      �� 	 � ��

 ���� 6;   �� 5�      	 � ��

 �����6;   �� 5�      	 � ��

 ���� 6<   �� 5�      	 � ��$
 0q�6@   �� 5�      	 � ��
 5�   "   �� 5�   &   " ��66   .R�5�   *   �� $ border��61   #��z��6A   $
 17.5��6k   ._�5�   .   �� $��Center=�6?   $��Center=�6\   5�   +    5�   *   P� 5�   .    �@J�IsMouseOver$
 True��6M   . �5�   2   �� $ border��69   	 � ��
 �#f443366c   �� 5�   2   	 � ��

 �����6O   5�   /   5�   '   5�      5�      5�      �� 5�      -   5        $��	btnVolver��5�      $��Volver��6*   $
��Left=�6;   $��436,391,0,0q�6V   $	��Top=�6k   $��29��6�   $	��110��6�   ���#400101���#DEDEDE$*��$pack://application:,,,/font/#Maxwell)�6�   $
��Bold"�6�   6	  5�      5�      5�      5�      