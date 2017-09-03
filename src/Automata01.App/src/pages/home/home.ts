import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { AutomataViewModel } from '../../shared/viewModels/automataViewModel';
import { RepositoryBase } from '../../repositories/repositoryBase';
import { ResultPage } from '../result/result';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  viewModel: AutomataViewModel;
  constructor(private repository: RepositoryBase, private navContorller: NavController) {
    this.viewModel = new AutomataViewModel();
  }

  enviar() {
    
    this.repository.post('home', this.viewModel).subscribe(x => this.navContorller.push(ResultPage, {result: x}));
  }
}
