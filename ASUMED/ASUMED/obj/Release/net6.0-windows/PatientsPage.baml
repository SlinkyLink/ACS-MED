   M S B A M L   `   `   `  ���� A  =ASUMED, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ASUMEDASUMED      ASUMED.PatientsPage   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     &localclr-namespace:ASUMED     -     N�Name$  PacientPage��$	��720��$
��1280�� N� Title$ PatientsPage�� � 	Resources  �� 
TargetType   
LeftBorder �� Property �� Value  	LeftLabel  
LabelRight  TexBoxRight  ControlElipse  
PhotoLabel  CtnMenuS  cmBorder  CtnMenuUpdate 	 cmBorderUpdate �� CornerRadius J� SnapsToDevicePixels �� Orientation
	 � Tag��%  &	        &	 y     &	      &	 l    &	 �    &	 �    &	 �    &		 �    &	     7  7  &	 �    7  �� " ��.���  � ��$ 4q���  � �� �	#7F29ABE2��  � ��$ 25����  �@��CornerRadius$ 10���� " ��.���  � ��
 �   ���  � ��$ 12(���  � ��$ Center=���  � ��$ Center=���  � ��$
 Bold"��� " ��.���  � ��$ 15(���  � ��
 �   ���  � ��$
 Bold"���  � ��$ Right=��� " ��.���  � ��$ 15(���  � ��$ 15����  � ��$ 0 4 0 4q���  �@��
IsReadOnly$
 True����  � ��$	 200���� " A�.���  � ��$ 35����  � ��$ 35����  � ��$ Center=���  � ��$ 	15 0 15 0q���  �@�Cursor$
 Hand���� " ��.���  � ��$ 25(���  � ��$
 Bold"���  � ��$ Center=��� #���  ���	#7F29ABE2�� #���  ���	#7F29ABE2�� " ��.���  � �� �� .R��� ���	#FF85BCD2$ 5��$��2q����	#FF29ABE2$
 True��._��� $ Vertical=�.+��� -   $	 DeleteB��$	��150��$��0q�
������ ���	#FF85BCD2._��� 8��  $��Видалити��$��Center=��� ���	#FF85BCD2
������ $��1q��� -   $	 UpdateB��$	��150��$��0q����	#FF85BCD2
������ ._��� 8�� $��Оновити��$��Center=��� " ��.���  � �� �� .R��� ���	#FF85BCD2$ 5��$��2q�
����  �$
 True��._��� $ Vertical=�.+��� -   $	 UpdateB��$	��150��$��0q����	#FF85BCD2
������ ._��� 8��  $��Оновити��$��Center=�.���� $ 15�����	#FF29ABE2._�� 
 � ColumnDefinitions
 �� $��3* ��� $��7* �.+��� $ 15��$��0�����	#FFA0DFF8$��0 0 1 0q�._��  � RowDefinitions �� $
��0.5* ��� $
��9.5* �.+��� -    ��Name$ LabelFSName��$��Center=�$��Center=�$��12(�$
��Bold"�
���   �$��First Last NAME���� $��1��$ Vertical=�$
��Auto=�$
��True��.+�� -    �Name$ ScrollViewerList��.+��� $
��Auto=�.���� -    ��Name$ ListPatientsPanel��$ Vertical=�.+��� #��[  ._��� #��[ $��	Exemple 1���� #��[  ._��� #��[ $��	Exemple 2���� #��[  ._��� #��[ $��	Exemple 3���� -   $ AddBtn��$ 
Horizontal=�$��Center=�.+�A� -	   #��[  � Cursor$
 Hand������  j� Stretch$ Uniform=� �� ImageSource$ Sources/AddIcon.png���� $ 15��$��1�����	#FFA0DFF8$��1q�._�� 
 �� $
��0.5* ��� $	��20* ��� $
��0.5* � �� $
��0.5* ��� $��4* ��� $��5* ��� $
��0.5* �.+�� $��1��$��1��
 �� $��2* ��� $��5* �.+�� $��0��.+��� $
��Auto=�$
��Auto=�.���� $��0��$��1��$��2q�
�������$
��Left=�$	��180��$	��240��._��� $ Vertical=�$��Center=�$��Center=�.+��� #��[ $��Фото���� #��[ $��Лікаря���� #��[ $	��3x4���� $
��Auto=�$
��Auto=�$��1��.���� $ 
Horizontal=�.+��� $ 
Horizontal=�$��Center=�.+��� $��1��$��0��$ Vertical=�$��Right=�$��Center=�.+��� #��[ .��ПІБ�� #��[ .��
Стать�� #��[ .��Дата народження�� #��[ .��Група крові�� #��[ .��Номер телефону�� $��1��$��1��$ Vertical=�$
��Left=�$��Center=�.+��� -
    ��Name$ TextBoxFLNameValue��#��[ �� -   $ TextBoxSexValue��#��[ �� -   $ TextBoxDayOfBirthValue��#��[ �� -   $ TextBoxRhesusFactorValue��#��[ �� -   $ TextBoxNumberPhoneValue��#��[ �� $��1��$��1��$ Vertical=�$
��Left=�$��Center=�.+��� #��[ .��
Зріст�� #��[ .��
Вага�� #��[ .��Стан лікування�� #��[ .��
Лікар�� $��1��$��1��$ Vertical=�$
��Left=�$��Center=�.+��� -   $ TextBoxGrowthValue��#��[ �� -   $ TextBoxWeightValue��#��[ �� -   $  TextBoxStateOfTherapyValue��#��[ �� -   $ TextBoxCreatedByValue��#��[ � $��2��$��1��.+��� -   $ TextBoxSickBook�� �� 
IsReadOnly$
 True�� �� AcceptsReturn$
 True��$
��Auto=�$
��Auto=�$
��True���� -    ��Name$ BorderBtnMedHist��$��3��$��1�����	#7F29ABE2$	��100��$��30��$��Center=�$��Right=�$ 10��._��� $|�False��$��14(�$��Exemple��$��
Myriad Pro)�$��Center=�$��Center=�
���   �