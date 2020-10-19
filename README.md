# 20201024CSTProject
Two programming level design for 2020 Computer Science tour which made by C#

# level info

## 凱薩密碼 (Caesar cipher)

### 介紹：

最廣為人知的一種加密方法，將明文（原文）向後位移 n 個字母成為密文。

![](https://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/Caesar3.svg/1920px-Caesar3.svg.png)
^上圖位移量為 +3。

### 題目：

將輸入透過凱薩加密成位移量為 -2 的英文密文。

### 程式碼：
```cpp=
#include <iostream>
using namespace std;
int main(){
    char c;
    while(cin>>c){
        if(c=='A'||c=='B'||c=='a'||c=='b'){ 
            c+=24;
        }else{
            c-=2;
        }
        cout<<c;
    }
    return 0;
}
```
#### 解析：
```cpp=6
        if(c=='A'||c=='B'||c=='a'||c=='b'){ 
```
ASCII編碼中 字母部分大小寫分別於 65~90 / 97~122 並以 A 開始排列到 Z，
所以位移量為 -2 的凱薩加密需額外針對 AB/ab 做出額外的控制，否則 AB/ab 無法加密為對應字母。

`||` 為邏輯運算值的 ++**或 (OR)**++ 意指其中一項條件成立則為真 (True)。



> 參考資料：[凱薩密碼 | 中文 Wiki](https://zh.wikipedia.org/wiki/%E5%87%B1%E6%92%92%E5%AF%86%E7%A2%BC)、[ASCII | 中文 Wiki](https://zh.wikipedia.org/wiki/ASCII)
---
## 最大公因數 (Greatest Common Divisor) - 輾轉相除法

### 介紹：

輾轉相除法是求兩數的最大公因數的演算法，首次出現於歐幾里得的《幾何原本》，故又稱歐幾里得演算法。

以 1112 與 695 兩數舉例。
![](https://i.imgur.com/4u4IEIX.png)
一般作法是因式分解兩數，從共同的質數中求出最大公因數。
但兩數越大，越難用因數分解得出質數。而輾轉相除法能夠更有效率地求出最大公因數。

![](https://i.imgur.com/vUhXY1t.png)
將兩數相除取餘數(mod)，除數與餘數將作為下一次的被除數與除數，相除後當餘數為 0 時，該除數就是兩數的最大公因數
>![](https://i.imgur.com/4FJFxn3.gif)
輾轉相除過程演示動畫

### 題目：

將輸入整數 a,b 求輸出該兩數之 GCD。

### 程式碼：
```cpp=
#include <iostream>
using namespace std;
void GCD(int a,int b){
    if(a%b!=0){
        GCD(b,a%b);
    }else{
        cout<<b;
    }
}

int main(){
    int a,b;
    cin>>a>>b;
    if(a>b){
        GCD(a,b);
    }else{
        GCD(b,a);
    }
    return 0;
}
```
#### 解析：
```cpp=3
    if(a%b!=0){
        GCD(b,a%b);
    }else{
        cout<<b;
    }
```
當 `餘數` (a%b) 為 0 時，就輸出 `除數` (b)
當 `餘數` (a%b) 不為 0 時，
`除數` (b) 成為下一次計算的 `被除數` (a)、`餘數` (a%b) 成為下一次計算的 `除數` (b)

### 額外補充：
輾轉相除法屬於經典的==遞迴==題目。

遞迴 (Recursive)：函式中包含自我呼叫 (self-calling)。
常見的遞迴題目還有：費式數列、河內塔、排列組合。

> 參考資料：[輾轉相除法 | 中文 Wiki](https://zh.wikipedia.org/wiki/%E8%BC%BE%E8%BD%89%E7%9B%B8%E9%99%A4%E6%B3%95)、[圖解演算法 | 博客來](https://www.books.com.tw/products/0010771263?gclid=Cj0KCQjwi7DtBRCLARIsAGCJWBpXQxRyhkrFhxl_zTjoJQMaPzipbDbDGVx66WlIV8DZoXVMqWHGt58aAnYKEALw_wcB)、[遞迴 | 中文 Wiki](https://zh.wikipedia.org/wiki/%E9%80%92%E5%BD%92)

> 延伸閱讀：[關於 GCD & LCM 與 Fastpower 筆記 (程式碼為 C 語言)](https://hackmd.io/@LpxP4PXkRH6K6mdUSl0_Vw/Hybtd9yFX)

---
