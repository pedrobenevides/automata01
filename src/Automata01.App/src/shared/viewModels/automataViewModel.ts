export class AutomataViewModel {
  alphabet: string;
  grammar: string;
  coordinates: string;

  constructor(data: any = {}) {
    this.alphabet = data.alphabet;
    this.grammar = data.grammar;
    this.coordinates = data.coordinates;
  }
}