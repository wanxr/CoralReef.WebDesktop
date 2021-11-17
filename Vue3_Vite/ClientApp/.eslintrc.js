module.exports = {
  root: true,
  env: {
    node: true
  },
  parserOptions: {
    ecmaVersion: '2022',
    sourceType: 'module',
    ecmaFeatures: {
      modules: true
    }
  },
  extends: ['plugin:vue/vue3-recommended', 'eslint:recommended', 'prettier'],
  rules: {
    'no-console': import.meta.env.MODE === 'production' ? 'warn' : 'off',
    'no-debugger': import.meta.env.MODE === 'production' ? 'warn' : 'off',
    'space-before-function-paren': 0,
    semi: 'off',
    'vue/multi-word-component-names': 'warn',
    'no-unused-vars': 'warn',
    'no-constant-condition': 'warn',
    'vue/no-unused-components': [
      'warn',
      {
        ignoreWhenBindingPresent: true
      }
    ],
    'spaced-comment': [
      'error',
      'always',
      {
        line: {
          markers: ['/'],
          exceptions: ['-', '+']
        },
        block: {
          markers: ['!'],
          exceptions: ['*'],
          balanced: true
        }
      }
    ]
  }
}
