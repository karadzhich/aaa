# --- ввод и вывод

# Hello, Harry!
print("Hello, " + input() + "!");

# следющее и предыдущее
a = int(input())
print("The next number for the number " + str(a) + " is " + str(a + 1))
print("The previous number for the number " + str(a) + " is " + str(a - 1))

# парты
a = int(input()) + int(input()) + int(input())
print(int((a + a % 2) / 2))

# шнурки
a = int(input())
b = int(input())
l = int(input())
n = int(input())
print(int(a * (n * 2 - 1)) + int(b * 2 * (n - 1)) + int(l * 2))

# --- условный оператор

# ход ферзя
a = int(input())
b = int(input())
c = int(input())
d = int(input())
if a == c:
    print("YES")
else:
    if b == d:
        print("YES")
    else:
        if (a + b) % 2 == (c + d) % 2:
            print("YES")
        else:
            print("NO")
            
# ход коня
a = int(input())
b = int(input())
c = int(input())
d = int(input())
diff1 = abs(a - c)
diff2 = abs(b - d)
if diff1 + diff2 == 3 and diff1 > 0 and diff2 > 0:
    print("YES")
else:
    print("NO")
    
# шоколадка
n = int(input())
m = int(input())
k = int(input())

if k < m * n and ((k % n == 0) or (k % m == 0)):
    print("YES")
else:
    print("NO")
    
# --- вычисления

# часы - 1
print("{0:.5f}".format((int(input()) * 30) + (int(input()) * 0.5) + (int(input()) * (0.5 / 60))))

# часы - 2
print(int(input()) % 30 * 12)

# часы - 3
alpha = float(input())
h = int(alpha // 30)
m = int(alpha % 30 // 0.5)
s = int(alpha / 30 * 3600 % 3600 % 60)
print(h, m, s)

# проценты
p = int(input())
x = int(input())
y = int(input())
r = (x * 100 + y) * (1 + p / 100)
print(int(r // 100), int(r % 100 // 1))

# --- цикл for

# нули
total = 0
for i in range(int(input())):
    if int(input()) == 0:
        total += 1
print(total)

# лесенка
for i in range(int(input())):
    for j in range(i + 1):
        print(j + 1, end = "")
    print()
	
# потерянная карточка
n = int(input())
total = 0
for i in range(n):
    total += (i + 1)
for j in range(n - 1):
    total -= int(input())
print(total)

# строки

# h -> H
s = input()
l = s.find('h')
r = s.rfind('h')
for i in range(len(s)):
    if s[i] == 'h' and i != l and i != r:
        s = s[:i] + 'H' + s[i+1:]
print(s)

# удалить каждый третий символ
