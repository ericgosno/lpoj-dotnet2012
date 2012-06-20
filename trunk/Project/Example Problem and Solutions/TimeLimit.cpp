#include<stdio.h>
#define MOD 1000

int pangkat(int A, int B)
{
    int c;
    int ans = 1;
    for(c=1;c<=B;c++) ans = (ans*A)%MOD;
    return ans;
}

int main()
{
    int T,a,b;
    scanf("%d",&T);
    while(T--)
    {
        scanf("%d%d",&a,&b);
        printf("%d\n",pangkat(a,b));
    }
    return 0;
}
