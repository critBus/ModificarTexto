/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 29/4/2022
 * Hora: 11:41
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using ReneUtiles.ReneWPF;
using ReneUtiles.ReneWPF.Clases;
using ReneUtiles;
using System.Text.RegularExpressions;
namespace ModificarTexto
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		TextBox T_entrada,T_Salida;//,T_caracter,T_numeroDeCaracter;
		CheckBox CB_DoblesSaltos;
		public Window1()
		{
			InitializeComponent();
			T_entrada=TB_Entrada;
			T_Salida=TB_Salida;
			//T_caracter=T_Caracter;
			
			CB_DoblesSaltos=CB_EliminarDoblesSaltos;
			
		}
		
		public void setTextoEntrada(string a){
			this.setText(T_entrada,a);
		}
		public string getTextoEntrada(){
			return UtilesWPF.getText(T_entrada);// T_entrada.Text.Replace("\r","");
		}
		public void setTextoSalida(string a){
		//	T_Salida.Text=a;
			this.setText(T_Salida,a);
		}
		public string getTextoSalida(){
			return this.getText(T_Salida);// T_entrada.Text.Replace("\r","");
		}
		public void setTextoEnTCaracter(string a){
			this.setText(T_Caracter,a);
		}
		public string getTextoCaracter(){
			return this.getText(T_Caracter);
		}
		public char getCaracter(){
			return getTextoCaracter()[0];
		}
		public char[] getListaDeCaracteres(){
			return getTextoCaracter().ToCharArray();
		}
		public bool estaTCaracterVacio(){
			return getTextoCaracter().Trim().Length==0;
		}
		
		public void setTextoEnTNumeroCaracter(string a){
			this.setText(T_NumeroDeCaracter,a);
		}
		public string getTextoNumeroCaracter(){
			return this.getText(T_NumeroDeCaracter);
		}
		public int getNumeroCaracter(){
			return this.inT(getTextoNumeroCaracter()); 
		}
		public bool estaTNumeroCaracterVacio(){
			return getTextoNumeroCaracter().Trim().Length==0;
		}
		public bool esUnNumeroElTNumeroCaracter(){
			return this.esNumero(getTextoNumeroCaracter());
		}
		
		public bool estaSeleccionadoEliminarDoblesSaltos(){
			//return CB_DoblesSaltos.IsChecked==true;
			return  this.isSelect(CB_DoblesSaltos);
		}
		public bool estaSeleccionadoCopiarYAplicar(){
			//return CB_PegarYAplicar.IsChecked==true;
			return  this.isSelect(CB_PegarYAplicar);
		}
		
		//public void pegarEnEntradaDePortapapelesDeSerNecesario(){}
		public string arreglosParche(string a){
			// =12
			// =19
			//=16
			//  í
			
			//i=6 =12 fi
			//i=11 =19 ó
			a=a.Replace(((char)12).ToString(),"fi");
			a=a.Replace(((char)19).ToString()+"u","ú");
			a=a.Replace(((char)19).ToString()+"o","ó");
			a=a.Replace(((char)19).ToString()+"a","á");
			a=a.Replace(((char)19).ToString()+"e","é");
			a=a.Replace(((char)19).ToString()+"i","í");
			a=a.Replace(((char)19).ToString()+((char)16).ToString(),"í");
			foreach (int c in new int[]{12,19,16}) {//{12,19,16
				a=a.Replace(((char)c).ToString(),"");
			}
			//i=2 =3
			//cwl(a);
			a=a.Replace(((char)3).ToString(),"*");
			string[][] ctilde={
				new string[]{" ´ı","í"}
				,new string[]{" ´ ı","í"}
				,new string[]{"´ı","í"}
				,new string[]{"ı´","í"}
				,new string[]{"I´ ","Í"}
				,new string[]{"I´","Í"}
				,new string[]{"´I","Í"}
				,new string[]{"´ i","í"}
				,new string[]{" ´ o","ó"}
				,new string[]{" ´o","ó"}
				,new string[]{"´ o","ó"}
				,new string[]{"´o","ó"}
				,new string[]{"o´","ó"}
				,new string[]{"O´ ","Ó"}
				,new string[]{"O´","Ó"}// ´ o
				,new string[]{"´O","Ó"}
				,new string[]{"a´","á"}
				,new string[]{"A´ ","Á"}
				,new string[]{"A´","Á"}
				,new string[]{"´A","Á"}
				
				,new string[]{" ´a","á"}
				,new string[]{" ´ a","á"}
				,new string[]{"´ a","á"}
				,new string[]{"´a","á"}
				,new string[]{" ´e","é"}
				,new string[]{"´ e","é"}
				,new string[]{" ´ e","é"}
				,new string[]{"´e","é"}
				,new string[]{"e´","é"}
				,new string[]{"E´ ","É"}
				,new string[]{"E´","É"}
				,new string[]{"´E","É"}
				
				
				,new string[]{" ´ u","ú"}//˜n
				,new string[]{" ´u","ú"}//˜n
				,new string[]{"´ u","ú"}
				,new string[]{"´u","ú"}//˜n
				,new string[]{"u´","ú"}
				,new string[]{"U´ ","Ú"}
				,new string[]{"U´","Ú"}
				,new string[]{"´U","Ú"}
				,new string[]{"˜n","ñ"}//˜n  //˜ n
				,new string[]{"˜ n","ñ"}//~N
				,new string[]{"~n","ñ"}
				,new string[]{"~N","Ñ"}//~n  //˜N
				,new string[]{"˜N","Ñ"}
				// ´a
			};
			foreach (string[] par in ctilde) {
				a=a.Replace(par[0],par[1]);
			}
			
			//emp´ırico
			// ´a
			return a;
		}
		public void realizarEdicionDeTexto(Func<string,string> getTextoEditado){
			if(estaSeleccionadoCopiarYAplicar()){
				setTextoEntrada(this.getTextoDeW());
			}
			string entrada=getTextoEntrada();
			entrada=arreglosParche(entrada);
			
//			entrada=entrada.Replace(((char)12).ToString(),"");
//			entrada=entrada.Replace(((char)19).ToString(),"");

		
			entrada=getTextoEditado(entrada);
			entrada=remplazardoblesSaltosSiEsNecesario(entrada);
			setTextoSalida(entrada);
			if(estaSeleccionadoCopiarYAplicar()){
				this.copiarW(getTextoSalida());
			}
		}
		
		public string remplazardoblesSaltosSiEsNecesario(string a){
			if(estaSeleccionadoEliminarDoblesSaltos()){
				while(this.containsOR(a,"\n\n"," \n","\n ")){//a.Contains("\n\n")
					//a=a.Replace("\n\n","\n");
					a=this.remplazarAll<string>(a,"\n","\n\n"," \n","\n ");
				}
			}
			return a;
		}
		
		public void showDlgNoPuedeEstarVacioTCaracter(){
			this.showDlgAdvertencia("No puede estar vacio el T Caracter");
		}
		public void showDlgNoPuedeEstarVacioTNumeroCaracter(){
			this.showDlgAdvertencia("No puede estar vacio el T Numero de Caracter");
		}
		public void showDlgNoEsUnNumeroTNumeroCaracter(){
			this.showDlgAdvertencia("El T Numero de Caracter tiene que ser un numero entero");
		}
		
		void Al_Apretar_En_Eliminar_Salto_De_Linea(object sender, RoutedEventArgs e)
		{
			realizarEdicionDeTexto(t => t.Replace("\n",""));
			//setTextoSalida(getTextoEntrada().Replace("\n",""));
			
		}
		void apreto_Sustituir_Salto_Por_Esapcios(object sender, RoutedEventArgs e)
		{
			//setTextoSalida(getTextoEntrada().Replace("\n"," "));
			realizarEdicionDeTexto(t => t.Replace("\n"," "));
		}
		void apreto_en_Copiar(object sender, RoutedEventArgs e)
		{
			this.copiarW(getTextoSalida());
		}
		void apreto_En_B_Caracter(object sender, RoutedEventArgs e)
		{
			if(estaTNumeroCaracterVacio()){
				showDlgNoPuedeEstarVacioTNumeroCaracter();
				return;
			}
			if(esUnNumeroElTNumeroCaracter()){
				showDlgNoEsUnNumeroTNumeroCaracter();
				return;
			}
			char a=(char)getNumeroCaracter();
			setTextoEnTCaracter(a+"");
			//realizarEdicionDeTexto(t => a + "");
		}
		void apreto_B_NumeroDeCaracter(object sender, RoutedEventArgs e)
		{
			if(estaTCaracterVacio()){
				showDlgNoPuedeEstarVacioTCaracter();
				return;
			}
			char a=getCaracter();
			int n=(int)a;
			setTextoEnTNumeroCaracter(n+"");
			//realizarEdicionDeTexto(t => n + "");
		}
		void apreto_SustituirSaltosDeLineaYCaracteresPorSaltos(object sender, RoutedEventArgs e)
		{
			realizarEdicionDeTexto(t => Utiles.remplazarAll(t.Replace("\n"," "),"\n",getListaDeCaracteres()));
			
//			string a=getTextoEntrada().Replace("\n"," ");
//			a=this.remplazarAll(a,"\n",getListaDeCaracteres()); 
//			a=remplazardoblesSaltosSiEsNecesario(a);
			
			//setTextoSalida(a);
		}
		void apreto_en_SustituirComaPorSaltosYSaltosPorEspacios(object sender, RoutedEventArgs e)
		{
			realizarEdicionDeTexto(t => t.Replace("\n"," ").Replace(",","\n"));
//			string a=getTextoEntrada().Replace("\n"," ");
//			a=a.Replace(",","\n");
//			a=remplazardoblesSaltosSiEsNecesario(a);
//			setTextoSalida(a);
		}
		void apreto_Pegar(object sender, RoutedEventArgs e)
		{
			setTextoEntrada(this.getTextoDeW());
		}
		//public Regex PATRON_NUMEROS=Regex(@"(\d+)");
		void apreto_SaltosDeLinieaYNumero(object sender, RoutedEventArgs e)
		{
			realizarEdicionDeTexto(t =>Regex.Replace(t.Replace("\n"," "), @"(\d+)","\n" ) );
				
		}
		void BEliminarTabuladoresYEspacios_Click(object sender, RoutedEventArgs e)
		{
			realizarEdicionDeTexto(t =>Utiles.recorrerLineasYModificar(t,(l,i)=>l.TrimStart()) );
		}
//		void Apreto_(object sender, RoutedEventArgs e)
//		{
//			throw new NotImplementedException();
//		}
		
		
		
		
		
		
		
	}
}