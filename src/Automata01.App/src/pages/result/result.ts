import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

@IonicPage()
@Component({
  selector: 'page-result',
  templateUrl: 'result.html',
})
export class ResultPage {
  model: Array<string> = [];
  finalStateMsg: string = "é o estado final !!";
  isValid: boolean = false;
  constructor(public navCtrl: NavController, public navParams: NavParams) {
  }

  ionViewDidLoad() {
    this.model = this.navParams.get("result");
    let lastElement = this.model.pop();
    this.isValid = lastElement.endsWith(this.finalStateMsg);
  }
}
