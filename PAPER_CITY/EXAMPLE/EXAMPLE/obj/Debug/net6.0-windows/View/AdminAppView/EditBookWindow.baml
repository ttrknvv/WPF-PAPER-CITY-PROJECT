   M S B A M L   `   `   `  ����D  @PaperCity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EXAMPLE.View.AdminAppViewEXAMPLE.View.AdminAppView  5   	   .    (EXAMPLE.View.AdminAppView.EditBookWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:EXAMPLE.View.AdminAppView     5   	   -   5        $��EditBook��5   	     � Title$  EditBookWindow��5   	   $	��660��5	   	   $	��760��5
   	   ���	#FFB8CEE7 � Icon$? 9D:\2k2s\COURSE_PROJECT\SOURCE\PHOTOES\addBookUnactive.png��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� .+�5      � .+�5      �� $	��200��6   $	��300��5      $��20, 0, 0, 0q�5      ._�5      �� -   5        $��BookSelectImage��5      $	��200��5      $	��300��5      $
��Left=�5      $��
0, 0, 0, 0q�5      5      5      �� 5      $��20, 0, 0, 0q�6   $	��500��5      .+�5       ��    NameBook#���   6    
���   �$��20(�5"      $��0, 10, 0, 10q�5#      �� 5$      -   5         ��Name$ NameBook��5$        
ForBuyBook#���  5%      $
��Left=�5&      $��30��5'      $��16(�5(      �� 5)        
AuthorBook#���  6    
���   �$��20(�5+      $��0, 10, 0, 10q�5,      �� 5-      -   5        $ 
AuthorBook��5-      #���  5.      $
��Left=�5/      $��30��50      $��16(�51      �� 52        	GenreBook#���  6    
���   �$��20(�54      $��0, 10, 0, 10q�55      �� 56      -   5        $ 	GenreBook��56      #���  57      $
��Left=�58      $��30��59      $��16(�5:      �� 5;        CostText#���  6    
���   �$��20(�5=      $��0, 10, 0, 10q�5>      �� 5?      -   5        $ CostBook��5?      #���  5@      $
��Left=�5A      $��30��5B      $��16(�5C      5D      5E      5F      �� 5G        DescriptionBook#���  6   $��20(�5H      $��20, 0, 0, 0q�5I      �� 5J      -   5        $ DescriptionBook��5J        ReviewStyleText#���  5K      $
��Left=�5L      $	��130��5M      $	��540��5N      $��20, 10, 0, 0q�5O      �� 5P        PathBook#���  6   $��20(�5Q      $��20, 10, 0, 0q�5R      � 5S      .+�5T      �� -   5        $ PathDownload��5T      #���  5U      $
��Left=�5V      $��30��5W      $	��340��5X      $��20, 10, 0, 0q�5Y      $��16(�5Z      5[      �� 5\      -	   5         ��Name$ 
VerifyPath��5\        	ButtonBuy#���  5]       	 IndicateBook#��� 	 5^      $��20, 0, 0, 0q�5_      $��30��5`      $��Bottom=�5a      $��18(�5b      5c      5d      � 5f      .+�5g      �� -
   5        $ AddBook��5g      #���  5h       
 
ChangeText#��� 
 5i      $��20, 20, 0, 0q�5j      5k      �� 5l      -   5        $ 	NoAddBook��5l      #���  5m       
 Cansel#���  5n      $��20, 20, 0, 0q�5o      5p      5q      5s      5v      5w      