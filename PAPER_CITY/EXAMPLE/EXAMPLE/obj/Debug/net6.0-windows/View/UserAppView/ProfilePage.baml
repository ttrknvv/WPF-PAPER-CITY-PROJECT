   M S B A M L   `   `   `  ����D  @PaperCity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EXAMPLE.ViewEXAMPLE.View  5          EXAMPLE.View.ProfilePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:EXAMPLE.View     5        N� 
Background
  ����  N� Title$ ProfilePage��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��320 �6   �� 5      $	��400 �6   .+�5   
   �� $��0��6   .+�5      �� -   5         ��Name$ ProfileImage��5      $	��280��5      $
��Auto��5      $
��Left=�5      $	��Top=�5      $��20, 18, 0, 0q�5      ��5   *   �� *LocalUserNow.IMAGE_PROFILE+5      �� 5         ChangeImage#���   6   $	��280��5      $��40��5      $
��Left=�5      $��20, 20, 0, 0q�5      $��20(�5        ForButtonSelectedBooks#���  5      ��5       �� *ChangeProfileImage+��5!      ��  �� ElementName$ ProfileImage��5"      �� 5#   
   $��1��6   .+�5$      ��   	PlugLogin#���  6   $��0, 14, 0, 0q�5%        TextPlug#���  5&      �� 5'      $��
0, 0, 0, 0q�5(        TextInfo#���  5)      ��5'      ��  �� Path$ LocalUserNow.LOGIN�5)      �� 5*       
 PNText#���  6   $��
0, 6, 0, 0q�5+      #���  5,      �� 5-      $��0, 0, 20, 0q�5.      #���  5/      ��5-      �� $ LocalUserNow.NAME�5/      �� 50        	EmailText#���  6   $��
0, 6, 0, 0q�51      #���  52      �� 53      $��
0, 0, 0, 0q�54      #���  55      ��53      �� $ LocalUserNow.EMAIL�55      �� 56        DateReg#���  6   $��
0, 6, 0, 0q�57      #���  58      �� 59      $��
0, 0, 0, 0q�5:      #���  5;      ��59      �� $$ LocalUserNow.DATE_REGISTRATION� �� StringFormat$ {0:dd.MM.yyyy}��5;      �� 5<        PhoneNumber#���  6   $
��Left=�5=      $��
0, 6, 0, 0q�5>      #���  5?      �� 5@      $��
0, 0, 0, 0q�5A      #���  5B      ��5@      �� $ LocalUserNow.PHONE_NUMBER�5B      �� 5C       	 
ChangeText#��� 	 6   $	��120��5D      $��40��6!   $��20(�5E      $��20, 14, 0, 0q�5F      #���  5G      ��5H      �� *ChangeProfilePhoneNumber+5I      5L      5N      