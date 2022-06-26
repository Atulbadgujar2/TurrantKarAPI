/* Copyright © 2021 ThinkAI (). All Rights Reserved.
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * 
 * Author: Atul Badgujar <atul.badgujar2@gmail.com>
 * Date: 25 Feb 2021
 * 
 * Contributor/s: 
 * Last Updated On: 25 Feb 2021
 */


using System.Threading.Tasks;

namespace TurrantKar.Data
{


  /// <summary>
  /// UnitOfWork Interface for Core Enitty
  /// </summary>
  public interface IUnitOfWork {

    /// <summary>
    /// Saves this instance.
    /// </summary>
    void Save();

    /// <summary>
    /// Saves the asynchronous.
    /// </summary>
    /// <returns></returns>
    Task SaveAsync();

    /// <summary>
    /// Saves all instances.
    /// </summary>
    /// <param name="enableSaveChnages">if set to <c>true</c> [enable save chnages].</param>
    /// <returns></returns>
    void SaveAll(bool enableSaveChnages = false);
  }
}
