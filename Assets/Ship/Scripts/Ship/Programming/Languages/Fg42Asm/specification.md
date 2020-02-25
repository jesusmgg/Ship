# Fg42 Assembly

## Registers
- `pin1`, `pin2`, `pin3`, etc.
- `mem`: working memory.

## Instruction set
- `mov dest source`: moves the source value to dest.
- `nop`: skips a cycle.
- `add dest source`: adds source to dest.
- `sub dest source`: subtracts source from dest.
- `msg source`: prints the source value to console.
- `cmp dest source`: compares source to dest and stores the result in the `mem` register (`0` for equal values, `1` for source > dest, `-1` for source < dest).
- `jmp dest`: jumps to dest label.
- `je dest`: jumps to dest label if `cmp` value is equal.
- `jne dest`: jumps to dest label if `cmp` value is not equal.
- `jg dest`: jumps to dest label if `cmp` value is greater.
- `jge dest`: jumps to dest label if `cmp` value is greater or equal.
- `jl dest`: jumps to dest label if `cmp` value is less.
- `jle dest`: jumps to dest label if `cmp` value is less or equal.

## Sample code
```
settings:
    

program:
```