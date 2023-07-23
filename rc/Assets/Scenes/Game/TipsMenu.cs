using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsMenu : MonoBehaviour {

	public Text textformul;
	public bool tipsMenuOpened = false;
	public GameObject TipsPanel;
	public GameObject UzorPanel;
	List<string> Algs = new List<string>() 
	{ "Слева: L' F L F'\n" +
	"Справа: R F' R' F",
	"Слева: L D' L' F L' F' L\n" +
	"Справа: R' D R F' R F R'",
	" F (R U R' U') F'\n"+
	"F (R U R' U')(R U R' U') F'",
	"Справа: R U R' U R U2 R'\n" +
	"Слева: L' U' L U' L U2 L",
	"Лямбда: R U R' F' (R U R' U') R' F R2 U' R' U' \n" +
	"Треугольник рёбер: R U' R U R U R U' R' U' R2",
	};
	List<string> Uzor = new List<string>() 
	{ "M E M' E'", "R2 L2 U2 D2 B2 F2", "(R L F B)x3", "(R L F B)x3 U2 D2",
		"1) (U' B2 U L' F2 L)x2\n 2) U2 F2 R2 U' L2 D B R' B R' B R' D' L2 U'\n 3) U' L2 F2 D' L' D U2 R U' R' U2 R2 U F' L' U R'",
		"U L2 D F D' B' U L' B2 U2 F U' F' U2 B' U'"
	};

	public void OpenCloseTips()
	{
		textformul.text = "";
		if (tipsMenuOpened == false)
		{
			TipsPanel.gameObject.SetActive(true);
			UzorPanel.gameObject.SetActive(false);
			tipsMenuOpened = true;
		}
		else
		{
			TipsPanel.gameObject.SetActive(false); tipsMenuOpened = false;
		}
	}
	public void but1() 
	{
		textformul.gameObject.SetActive(true);
		textformul.text = Algs[0];
		TipsPanel.gameObject.SetActive(false); tipsMenuOpened = false;
	}

	public void but2()
	{
		textformul.gameObject.SetActive(true);
		textformul.text = Algs[1];
		TipsPanel.gameObject.SetActive(false); tipsMenuOpened = false;
	}
	public void but3()
	{
		textformul.gameObject.SetActive(true);
		textformul.text = Algs[2];
		TipsPanel.gameObject.SetActive(false); tipsMenuOpened  = false;
	}

	public void but4()
	{
		textformul.gameObject.SetActive(true);
		textformul.text = Algs[3];
		TipsPanel.gameObject.SetActive(false); tipsMenuOpened = false;
	}

	public void but5()
	{
		textformul.gameObject.SetActive(true);
		textformul.text = Algs[4];
		TipsPanel.gameObject.SetActive(false); tipsMenuOpened = false;
	}

	public void but6()
	{
		TipsPanel.gameObject.SetActive(false); tipsMenuOpened = false;
		UzorPanel.gameObject.SetActive(true); 
	}
	public void Wishenka() 
	{
		textformul.gameObject.SetActive(true);
		textformul.text = Uzor[0];
		UzorPanel.gameObject.SetActive(false); tipsMenuOpened = false;

	}
	public void Chess()
	{
		textformul.gameObject.SetActive(true);
		textformul.text = Uzor[1];
		UzorPanel.gameObject.SetActive(false); tipsMenuOpened = false;
	}
	public void Zig()
	{
		textformul.gameObject.SetActive(true);
		textformul.text = Uzor[2];
		UzorPanel.gameObject.SetActive(false); tipsMenuOpened = false;
	}
	public void Zmei()
	{
		textformul.gameObject.SetActive(true);
		textformul.text = Uzor[3];
		UzorPanel.gameObject.SetActive(false); tipsMenuOpened = false;
	}
	public void Cubes()
	{
		textformul.gameObject.SetActive(true);
		textformul.text = Uzor[4];
		UzorPanel.gameObject.SetActive(false); tipsMenuOpened = false;
	}
	public void Corner()
	{
		textformul.gameObject.SetActive(true);
		textformul.text = Uzor[5];
		UzorPanel.gameObject.SetActive(false); tipsMenuOpened = false;
	}
}
