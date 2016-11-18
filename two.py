# строки
#
s = input()
s = s.replace("h", "H")
s = s.replace("H", "h", 1)
s = s[0:s.rfind("H")] + "h" + s[s.rfind("H") + 1:]

#
print(s)
s = input()
for i in range(len(s)):
    if i % 2 == 0:
        s = s[0:i] + s[i+1:]
print(s)

# while
#
cnt = 1
mcnt = 1
curr = int(input())
inp = curr
while inp != 0:
    inp = int(input())
    if inp == curr:
        cnt += 1
    else:
	    if mcnt < cnt:
	        mcnt = cnt
	    curr = inp
	    cnt = 1
else:
    if mcnt < cnt:
	    mcnt = cnt
print(mcnt)

#
from math import *

all = []
inp = int(input())
while inp != 0:
    all.append(inp)
    inp = int(input())
n = len(all)
s = 0
for i in range(n):
    s += all[i]
s /= n
ch = 0
for i in range(n):
    ch += (all[i] - s) ** 2
o = sqrt(ch / (n - 1))

print (round(o, 11))

# списки
#
kg = []
n, k = map(int, input().split(' '))
for i in range(n):
    kg.append("I")
for i in range(k):
    s, e = map(int, input().split(' '))
    for j in range(s - 1, e):
        kg[j] = "."
for i in range(n):
    print(kg[i], end = "")
    
#
kg = []
if 1 == 1:
    for o in range(8):
        k, g = map(int, input().split(' '))
        kg.append(k)
        kg.append(g)
    res = False
    for i in range(8):
        for j in range(8):
            if i != j:
                if kg[i * 2] == kg[j * 2]:
                    res = True
                else:
                    if kg[i * 2 + 1] == kg[j * 2 + 1]:
                        res = True
                    else:
                        if (kg[i * 2] + kg[j * 2]) % 2 == (kg[i * 2 + 1] + kg[j * 2 + 1]) % 2:
                            res = True
                        else:
                            res = False
    if res:
        print("YES")
    else:
        print("NO")

# функции
#
def rr():
    n = int(input())
    if n == 0:
        print(n)
        return 1
    if rr() == 1:
        print(n)
        return 1
        
rr()

#
def fib(n):
    if n == 0:
        return 0
    if n == 1:
        return 1
    if n >= 2:
        return fib(n - 1) + fib(n - 2)

print(fib(int(input())))

# двумерные массивы
#
n = int(input())
a = [[0] * n for i in range(n)]
for i in range(n - 1, -1, -1):
    for j in range(n - 1, -1, -1):
        if i + j == n - 1:
            a[i][j] = 1
        if i + j > n - 1:
            a[i][j] = 2
for i in range(n):
    for j in range(n):
        print(a[i][j], end = " ")
    print()
    
#
n = int(input().split(' ')[0])
a = []
for i in range(n):
    a.append([int(j) for j in input().split()])
l, m = map(int, input().split(' '))
for j in range(len(a)):
    a[j][l], a[j][m] = a[j][m], a[j][l]
for i in range(n):
    for j in range(len(a[0])):
        print(a[i][j], end = " ")
    print()
