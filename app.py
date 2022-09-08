class Node:
    def __init__(self):
        self.chliden = {}
        self.flag = False

class Tries:
    def __init__(self):
        self.root = Node()

    def getRoot(self):
        return self.root

    def printTries(self):
        last = False
        i = 0
        for key in self.root.chliden.keys():
            print("+-" + key)
            if i == len(self.root.chliden) - 1:
                last = True
            self.printTrie(self.root.chliden[key], "", last)
            i += 1

    def printTrie(self, dic, indent, last):
        i = 0
        tmp = False
        indent += "   " if last else "|  "
        for key in dic.chliden.keys():
            print(indent + "+-" + key)
            if i == len(dic.chliden) - 1:
                tmp = True
            self.printTrie(dic.chliden[key], indent, tmp)
            i += 1

    def contains(self, word):
        current = self.root
        for c in word:
            if c not in current.chliden.keys():
                return False
            current = current.chliden[c]
        return current.flag

    def inseart(self, text):
        s = list(text)
        i = 0
        current = self.root
        while i < len(s):
            if s[i] in current.chliden.keys():
                current = current.chliden[s[i]]
            else:
                node = Node()
                current.chliden[s[i]] = node
                current = node
            i += 1
        current.flag = True

if __name__ == '__main__':
    tries = Tries()
    tries.inseart("jame")
    tries.inseart("jim")
    tries.inseart("joy")
    tries.inseart("jack")
    tries.inseart("big")
    tries.printTries()
# +-j
# |  +-a
# |  |  +-m
# |  |  |  +-e
# |  |  +-c
# |  |     +-k
# |  +-i
# |  |  +-m
# |  +-o
# |     +-y
# +-b
#    +-i
#       +-g