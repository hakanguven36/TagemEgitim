using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagemEgitim.ViewModels
{
	public class GelismisİstatistikViewModel
	{
		public DateTime? tarihStart { get; set; }
		public DateTime? tarihEnd { get; set; }
		public bool ulus_u { get; set; }
		public bool ulus_a { get; set; }
		public bool ev_s { get; set; }
		public bool ev_o { get; set; }
		public bool topl_c { get; set; }
		public bool topl_e { get; set; }
		public bool topl_t { get; set; }
	}
}
