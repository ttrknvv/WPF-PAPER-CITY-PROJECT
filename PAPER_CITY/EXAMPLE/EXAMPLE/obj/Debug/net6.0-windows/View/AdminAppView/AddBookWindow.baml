   M S B A M L   `   `   `  ����D  @PaperCity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EXAMPLE.View.AdminAppViewEXAMPLE.View.AdminAppView  5   	   -    'EXAMPLE.View.AdminAppView.AddBookWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:EXAMPLE.View.AdminAppView     5   	   -   5        $��AddBookWind��5   	     � Title$  AddBookWindow��5	   	   $	��660��5
   	   $	��760��5   	   ���	#FFB8CEE7 � Icon$? 9D:\2k2s\COURSE_PROJECT\SOURCE\PHOTOES\addBookUnactive.png��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� .+�5      � .+�5      �� $	��200��6   $	��300��5      $��20, 0, 0, 0q�5      ._�5      �� -   5        $��BookSelectImage��5      $	��200��5      $	��300��5      $
��Left=�5      $��5q�5      $
��Fill=�5      $@��:D:\2k2s\COURSE_PROJECT\SOURCE\PHOTOES\BookNotPhotoIcon.png��5      5      5      �� 5       $��20, 0, 0, 0q�6   $	��500��5!      .+�5"      ��    NameBook#���   6    
���   �$��20(�5$      $��0, 10, 0, 10q�5%      �� 5&      -   5         ��Name$ NameBook��5&        
ForBuyBook#���  5'      $
��Left=�5(      $��30��5)      $��16(�5*      �� 5+        
AuthorBook#���  6    
���   �$��20(�5-      $��0, 10, 0, 10q�5.      �� 5/      -   5        $ 
AuthorBook��5/      #���  50      $
��Left=�51      $��30��52      $��16(�53      �� 54        	GenreBook#���  6    
���   �$��20(�56      $��0, 10, 0, 10q�57      �� 58      -   5        $ 	GenreBook��58      #���  59      $
��Left=�5:      $��30��5;      $��16(�5<      �� 5=        CostText#���  6    
���   �$��20(�5?      $��0, 10, 0, 10q�5@      �� 5A      -   5        $ CostBook��5A      #���  5B      $
��Left=�5C      $��30��5D      $��16(�5E      5F      5G      5H      �� 5I        DescriptionBook#���  6   $��20(�5J      $��20, 0, 0, 0q�5K      �� 5L      -   5        $ DescriptionBook��5L        ReviewStyleText#���  5M      $
��Left=�5N      $	��130��5O      $	��540��5P      $��20, 10, 0, 0q�5Q      �� 5R        PathBook#���  6   $��20(�5S      $��20, 10, 0, 0q�5T      � 5U      .+�5V      �� -   5        $ PathDownload��5V      #���  5W      $
��Left=�5X      $��30��5Y      $	��340��5Z      $��20, 10, 0, 0q�5[      $��16(�5\      �� 5]      -	   5         ��Name$ 
VerifyPath��5]        	ButtonBuy#���  5^       	 IndicateBook#��� 	 5_      $��20, 0, 0, 0q�5`      $��30��5a      $��Bottom=�5b      $��18(�5c      5d      5e      � 5g      .+�5h      �� -
   5        $ AddBook��5h      #���  5i       
 AddText#��� 
 5j      $��20, 20, 0, 0q�5k      ��5l      �� *AddBookFinally+��5m      ��  �� ElementName$ AddBookWind���� 5n      -   5        $ 	NoAddBook��5n      #���  5o       
 Cansel#���  5p      $��20, 20, 0, 0q�5q      5r      5s      5u      5x      5y      